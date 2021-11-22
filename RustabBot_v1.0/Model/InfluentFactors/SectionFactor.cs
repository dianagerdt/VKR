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
        private double _reaction;
        
        /// <summary>
        /// Тип фактора Переток в сечении
        /// </summary>
        public override string FactorType => "Переток";

        //У каждого сечения - свой список регулирующих генераторов
        private List<int> _regulatingGeneratorsList = new List<int>();


        public List<int> RegulatingGeneratorsList
        {
            get
            {
                return _regulatingGeneratorsList;
            }

            set
            {
                _regulatingGeneratorsList = value;
            }
        }

        public double Reaction
        {
            get
            {
                return _reaction;
            }

            set
            {
                _reaction = value;
            }
        }

    }
}
