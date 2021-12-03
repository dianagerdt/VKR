using System;
using System.Collections.Generic;
using System.Linq;
using ASTRALib;
using System.ComponentModel;
using System.IO;
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
        /// Поле для реакции перетока в сечении на шаг по траектории
        /// </summary>
        private double _reaction;
        
        /// <summary>
        /// Тип фактора Переток в сечении
        /// </summary>
        public override string FactorType => "Переток";

        /// <summary>
        /// Поле для списка генераторов, поддерживающих переток в этом сечении
        /// </summary>
        private List<int> _regulatingGeneratorsList = new List<int>();

        /// <summary>
        /// Список генераторов, поддерживающих переток в этом сечении
        /// </summary>
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

        /// <summary>
        /// Реакция перетока в сечении на шаг по траектории
        /// </summary>
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

        /// <summary>
        /// Коррекция траектории утяжеление в процессе расчёта
        /// </summary>
        public static void CorrectTrajectory(InfluentFactorBase sectionFactor)
        {

            if(sectionFactor.CurrentValue < sectionFactor.MinValue)
            {
                for (int i = 0; i < ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count; i++) //для каждого генератора данного сечения
                {
                    double initialIncrement = RastrSupplier.GetValue("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "pg");
                    double addIncrement = (sectionFactor.MaxValue - sectionFactor.MinValue) / (((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count);
                    RastrSupplier.SetValue("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "pg", initialIncrement + addIncrement); //приращение генерации пересчитанное
                }
            }

            if (sectionFactor.CurrentValue > sectionFactor.MaxValue)
            {
                for (int i = 0; i < ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count; i++) //для каждого генератора данного сечения
                {
                    double initialIncrement = RastrSupplier.GetValue("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "pg");
                    double addIncrement = -(sectionFactor.MaxValue - sectionFactor.MinValue) / (((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count);
                    RastrSupplier.SetValue("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "pg", initialIncrement + addIncrement); //приращение генерации пересчитанное
                }
            }
        }

    }
}
