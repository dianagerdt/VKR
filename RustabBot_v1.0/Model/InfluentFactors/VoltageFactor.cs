using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfluentFactors
{
    public class VoltageFactor : InfluentFactorBase
    {
        /// <summary>
        /// Тип фактора Напряжение
        /// </summary>
        public override string FactorType => "Напряжение";
    }
}
