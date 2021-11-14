using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Базовый класс для влияющих факторов
    /// </summary>
    public abstract class InfluentFactorBase
    {
        /// <summary>
        /// Экземпляр класса RastrSupplier для операций 
        /// над данными из таблиц RastrWin
        /// </summary>
        protected RastrSupplier _rastrSupplier = new RastrSupplier();
        
        /// <summary>
        /// Нижняя граница для фактора
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Верхняя граница для фактора
        /// </summary>
        private double _maxValue;

        /// <summary>
        /// Текущее значение фактора
        /// </summary>
        private double _currentValue;

        /// <summary>
        /// Идентификатор из RastrWin
        /// </summary>
        protected int _numberFromRastr;

        /// <summary>
        /// Тип фактора
        /// </summary>
        public abstract string FactorType { get; }

        /// <summary>
        /// Идентификатор из RastrWin
        /// </summary>
        public int NumberFromRastr
        {
            get
            {
                return _numberFromRastr;
            }
            set
            {
                _numberFromRastr = value;
            }
        }

        /// <summary>
        /// Нижняя граница для фактора
        /// </summary>
        public double MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
            }
        }

        /// <summary>
        /// Верхняя граница для фактора
        /// </summary>
        public double MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
            }
        }

        /// <summary>
        /// Текущее значение фактора
        /// </summary>
        public double CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = Math.Round(value, 2);
            }
        }

        /// <summary>
        /// Проверка, входят ли факторы в диапазон
        /// сравнивается с текущим значением
        /// </summary>
        public bool IsInDiapasone(double minValue, double maxValue, double currentValue)
        {
            if (currentValue > maxValue || currentValue < minValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Проверка, корректны ли границы диапазона, которые ввёл пользователь
        /// </summary>
        public static bool IsMinMaxCorrect(double minValue, double maxValue)
        {
            if (minValue > maxValue || maxValue == minValue)
            {
                throw new Exception("Проверьте ввод максимального и минимального значения диапазона!");
            }
            else
            {
                return true;
            }
        }
    }
}
