﻿using System;
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
        protected double _numberFromRastr;

        /// <summary>
        /// Тип фактора
        /// </summary>
        public abstract string FactorType { get; }

        /// <summary>
        /// Номер узла/сечения, в зависимости от типа ВФ 
        /// </summary>
        public double NumberFromRastr
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
                _currentValue = Math.Round(value, 2);
            }
        }

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

        public static bool IsMinMaxCorrect(double minValue, double maxValue)
        {
            if(minValue > maxValue || maxValue == minValue)
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
