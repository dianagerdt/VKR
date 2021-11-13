using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfluentFactors
{
    /// <summary>
    /// Влияющий фактор - Нагрузка
    /// </summary>
    public class LoadFactor : InfluentFactorBase
    {
        /// <summary>
        /// Тип фактора Нагрузка
        /// </summary>
        public override string FactorType => "Нагрузка";
    }
}
