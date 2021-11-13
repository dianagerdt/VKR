using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

namespace Model.InfluentFactors
{
    /// <summary>
    /// Влияющий фактор - Напряжение в узле
    /// </summary>
    public class VoltageFactor : InfluentFactorBase
    {
        /// <summary>
        /// Тип фактора Напряжение
        /// </summary>
        public override string FactorType => "Напряжение";

    }
}
