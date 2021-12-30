using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

namespace Model.InfluentFactors
{
    /// <summary>
    /// Влияющий фактор - Напряжение на шинах
    /// исследумой станции
    /// Регулируется генераторами исследуемой станции (изм. Vзад.)
    /// </summary>
    [Serializable]
    public class VoltageFactor : InfluentFactorBase
    {
        /// <summary>
        /// Тип фактора Напряжение
        /// </summary>
        public override string FactorType => "Напряжение";

        /// <summary>
        /// Метод для коррекции V_зд у генераторов для поддержания напряжения-влияющего фактора
        /// </summary>
        public static void CorrectVoltage(List<int> listOfGenerators, InfluentFactorBase voltageFactor)
        {
            if(voltageFactor.CurrentValue < voltageFactor.MinValue)
            {
                for (int i = 0; i < listOfGenerators.Count; i++)
                {
                    double vzdOfGen = RastrSupplier.GetValue("node", "ny", listOfGenerators[i], "vzd");
                    double uhomOfGen = RastrSupplier.GetValue("node", "ny", listOfGenerators[i], "uhom");

                    if (vzdOfGen < setMaxValueForVoltage(uhomOfGen))
                    {
                        RastrSupplier.SetValue("node", "ny", listOfGenerators[i], "vzd", vzdOfGen + 0.1);
                    }
                    else
                    {
                        RastrSupplier.SetValue("node", "ny", listOfGenerators[i], "vzd", setMaxValueForVoltage(uhomOfGen));
                    }
                }
            }

            if (voltageFactor.CurrentValue > voltageFactor.MaxValue)
            {
                for (int i = 0; i < listOfGenerators.Count; i++)
                {
                    double vzdOfGen = RastrSupplier.GetValue("node", "ny", listOfGenerators[i], "vzd");
                    double uhomOfGen = RastrSupplier.GetValue("node", "ny", listOfGenerators[i], "uhom");

                    if (vzdOfGen > setMinValueForVoltage(uhomOfGen))
                    {
                        RastrSupplier.SetValue("node", "ny", listOfGenerators[i], "vzd", vzdOfGen - 0.1);
                    }
                    else
                    {
                        RastrSupplier.SetValue("node", "ny", listOfGenerators[i], "vzd", setMinValueForVoltage(uhomOfGen));
                    }
                }
            }
        }

        /// <summary>
        /// Максильмано возможное значение V_зд генератора
        /// </summary>
        private static double setMaxValueForVoltage(double vzd)
        {
            return vzd * 1.05; 
        }

        /// <summary>
        /// Минимально возможное значение V_зд генератора
        /// </summary>
        private static double setMinValueForVoltage(double vzd)
        {
            return vzd * 0.95; 
        }
    }
}
