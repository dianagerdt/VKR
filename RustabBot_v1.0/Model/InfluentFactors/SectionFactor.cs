using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfluentFactors
{
    /// <summary>
    /// Влияющий фактор - Переток в сечении
    /// </summary>
    public class SectionFactor : InfluentFactorBase
    {
        /// <summary>
        /// Тип фактора Переток в сечении
        /// </summary>
        public override string FactorType => "Переток";
    }
}
