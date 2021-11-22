using System;
using System.Collections.Generic;
using System.Linq;
using ASTRALib;
using System.ComponentModel;
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
        public static void CorrectTrajectory(BindingList<InfluentFactorBase>
            factorList, List<int> researchingPlantGenerators, string rg2FileName, Rastr rastr, InfluentFactorBase sectionFactor)
        {
            ITable tableForIncrement = rastr.Tables.Item("ut_node");
            ICol columnForStatement = tableForIncrement.Cols.Item("sta");
            string shablonRg2 = @"../../Resources/режим.rg2";

            //Приращения для ВСЕХ сечений-факторов выставляем равным нулю (иначе говоря, их строки отключается)
            foreach (var factor in factorList)
            {
                if (factor is SectionFactor) //если ВФ это сечение
                {
                    for (int j = 0; j < ((SectionFactor)factor).RegulatingGeneratorsList.Count; j++)
                    {
                        RastrSupplier.SetBool("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[j], "sta", true);
                    }
                }
            }

            double initialSectionPower = Math.Round(RastrSupplier.GetValue("sechen", "ns", sectionFactor.NumberFromRastr, "psech"), 0);

            //Расчёт шага утяжеления только основными ГГ (после первого шага цикл прерывается)
            if (rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
            {
                rastr.ut_FormControl();
                rastr.ClearControl();
                RastrRetCode kod = rastr.step_ut("i");
                if (kod == 0)
                {
                    RastrRetCode kd;
                    do
                    {
                        //шаг утяжеления
                        kd = rastr.step_ut("z");
                        if (((kd == 0) && (rastr.ut_Param[ParamUt.UT_ADD_P] == 0)) || rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            rastr.AddControl(-1, "");
                        }
                        //шаг утяжеления

                        double sectionPowerAfterStep = Math.Round(RastrSupplier.GetValue("sechen", "ns", sectionFactor.NumberFromRastr, "psech"), 0); //значение перетока после шага утяжеления

                        if (sectionPowerAfterStep == initialSectionPower) //если переток НЕ изменился после шага утяжеления, то приращения остаются равными нулю
                        {
                            ((SectionFactor)sectionFactor).Reaction = 0;
                            return;
                        }
                        else //если переток меняется, значит есть зависимость -> нужно рассчитать приращение
                        {
                            ((SectionFactor)sectionFactor).Reaction = sectionPowerAfterStep - initialSectionPower; //расчёт реакции 

                            //Обратно включаем номера влияющих генераторов в таблице приращений
                            for (int i = 0; i < ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count; i++)
                            {
                                RastrSupplier.SetBool("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "sta", false);
                            }

                            //Выключаем номера ГГ исследуемой станции
                            for (int i = 0; i < researchingPlantGenerators.Count; i++)
                            {
                                RastrSupplier.SetBool("ut_node", "ny", researchingPlantGenerators[i], "sta", true);
                            }
                        }
                        break; //прерываем после одного шага
                    }
                    while (kd == 0);
                }
            }
            
            //Траектория готова. Делаем по ней шаг, чтобы рассчитать коэффициент влияния влияющих ГГ
            //на сечение-ВФ c их текущим шагом, который был рассчитан до начала основного расчёта

            double powerFlowAfterStep;

            //Загружаем исходный режим

            RastrSupplier.LoadFile(rg2FileName, shablonRg2);

            if (rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
            {
                rastr.ut_FormControl();
                rastr.ClearControl();
                RastrRetCode kod = rastr.step_ut("i");
                if (kod == 0)
                {
                    RastrRetCode kd;
                    do
                    {
                        kd = rastr.step_ut("z");
                        if (((kd == 0) && (rastr.ut_Param[ParamUt.UT_ADD_P] == 0)) || rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            rastr.AddControl(-1, "");
                        }
                        // Шаг выполнен. Определяем реакцию

                        powerFlowAfterStep = RastrSupplier.GetValue("sechen", "ns", sectionFactor.NumberFromRastr, "psech"); //фиксируем переток ПОСЛЕ

                        double InfluentCoeff = ((powerFlowAfterStep - initialSectionPower) / ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count); 
                        double compensationPower = ((SectionFactor)sectionFactor).Reaction / InfluentCoeff; 
                        double increment = compensationPower / ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count; 

                        // присваиваем приращение в таблице траектории

                        for (int i = 0; i < ((SectionFactor)sectionFactor).RegulatingGeneratorsList.Count; i++) //для каждого генератора данного сечения
                        {
                            RastrSupplier.SetValue("ut_node", "ny", ((SectionFactor)sectionFactor).RegulatingGeneratorsList[i], "pg", increment); //приращение генерации пересчитанное
                        }
                        break;
                    }
                    while (kd == 0);
                }
            }

             //Обратно включаем все строки
            for (int i = 0; i < tableForIncrement.Count; i++)
            {
                columnForStatement.set_Z(i, false);
            }

            //Опять исходный режим
            RastrSupplier.LoadFile(rg2FileName, shablonRg2);
        }

    }
}
