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
        public RastrSupplier _rastrSupplier = new RastrSupplier();

        private double _minValue;
        private double _maxValue;
        private double _currentValue;
        private int _numberFromRastr;

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

        public void ShowCurrentValueFromRastr()
        {

        }
    }
}
