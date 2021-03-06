using System;
using Model.InfluentFactors;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Базовый класс для влияющих факторов
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(SectionFactor))]
    [XmlInclude(typeof(VoltageFactor))]

    public abstract class InfluentFactorBase
    {
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
                _minValue = Math.Round(value, 0);
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
                _maxValue = Math.Round(value, 0);
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
                _currentValue = Math.Round(value, 0);
            }
        }

        /// <summary>
        /// Проверка, входят ли факторы в диапазон
        /// сравнивается с текущим значением
        /// </summary>
        public static bool IsInDiapasone(InfluentFactorBase influentFactor)
        {
            if (influentFactor.CurrentValue > influentFactor.MaxValue || influentFactor.CurrentValue < influentFactor.MinValue)
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
