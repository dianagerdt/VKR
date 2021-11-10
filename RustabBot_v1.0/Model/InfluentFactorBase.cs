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
        protected RastrSupplier _rastrSupplier = new RastrSupplier();

        private double _minValue;
        private double _maxValue;
        private double _currentValue;
        protected int _numberFromRastr;

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

        public double CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
            }
        }

        /// <summary>
        /// Номер узла/сечения, в зависимости от типа ВФ 
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
        /// Тип фактора
        /// </summary>
        public abstract string FactorType { get; }

        public static bool IsInDiapasone(double minValue, double maxValue, double currentValue)
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
    }
}
