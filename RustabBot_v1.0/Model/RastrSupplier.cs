using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using ASTRALib;
using Model.InfluentFactors;

namespace Model
{
    /// <summary>
    /// Класс, осуществляющий взаимодействие с RastrWin3
    /// </summary>
    public class RastrSupplier
    {
        /// <summary>
        /// Экземпляр класса Rastr
        /// </summary>
        private static Rastr _rastr = new Rastr();

        /// <summary>
        /// Экземпляр сообытия - сообщение
        /// </summary>
        public static event EventHandler<EventProvider> Message;

        /// <summary>
        /// Загрузка файла в рабочую область 
        /// </summary>
        public static void LoadFile (string filePath, string shablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, filePath, shablon);
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        public static void SaveFile(string fileName, string shablon)
        {
            try //если нет лицензии, то файл не сохранится
            {
                _rastr.Save(fileName, shablon); 
            }
            catch(Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Ошибка!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Создание файла с помощью загрузки шаблона
        /// </summary>
        public static void CreateFile(string shablon)
        {
            _rastr.NewFile(shablon);
        }

        /// <summary>
        /// Узнать индекс из таблицы по номеру 
        /// </summary>
        /// <param name="tableName" - название таблицы, в которой ведется поиск></param>
        /// <param name="parameterName" - название параметра, по которому ищется индекс></param>
        /// <param name="number" - номер узла (может быть так же номером сечения)></param>

        public static int GetIndexByNumber(string tableName, string parameterName, int number)
        {
            ITable table = _rastr.Tables.Item(tableName); 
            ICol columnItem = table.Cols.Item(parameterName);

            for (int index = 0; index < table.Count; index++)
            {
                if (columnItem.get_ZN(index) == number)
                {
                    return index;
                }
            }
            throw new Exception($"Узел/сечение с номером {number} не найден(о).");
        }

        /// <summary>
        /// Получить значение из любой ячейки любой таблицы
        /// </summary>
        /// <param name="tableName" - название таблицы, в которой ведется поиск></param>
        /// <param name="parameterName" - название параметра, по которому ищется индекс></param>
        /// <param name="number" - номер узла (может быть так же номером сечения)></param>
        /// <param name="chosenParameter" - любой параметр, значение из ячеек которого нужно получить
        /// (например, модуль текущего напряжения в узле)
        public static double GetValue(string tableName, string parameterName, 
            int number, string chosenParameter)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            return columnItem.get_ZN(index);
        }

        public static string GetStringValue(string tableName, string parameterName,
            int number, string chosenParameter)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            return columnItem.get_ZN(index);
        }

        /// <summary>
        /// Проверяет режим
        /// </summary>
        /// <returns> Возвращает true - расчет завершен успешно,
        /// false - аварийное завершение расчета</returns>
        public static bool IsRegimeOK()
        {
            var statusRgm = _rastr.rgm("");

            if (statusRgm == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Рассчитывает режим
        /// </summary>
        public static void Regime()
        {
            _rastr.rgm("");
        }

        /// <summary>
        /// Записывает желаемое значение в любую ячейку таблицы
        /// </summary>
        public static void SetValue(string tableName, string parameterName, int number, 
            string chosenParameter, double value)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            columnItem.set_ZN(index, value);
        }

        /// <summary>
        /// Алгоритм расчёта траектории и переходных процессов по заранее подготовленным сценариям
        /// </summary>
        public static void Worsening(BindingList<InfluentFactorBase> factorList, int maxIteration,
            List<int> researchingPlantGenerators, int iteration, int ResearchingSectionNumber, string rstFileName,
            List<string> scnFileNames)
        {

            string shablonRst = @"../../Resources/динамика.rst";
            string shablonScn = @"../../Resources/сценарий.scn";
            int stepCounter = 0;
            double powerInSectionWhenStabilityIsOK = 0;
            //подпишемся на это событие в MainForm
            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Исследуемое сечение -" +
                        $" '{GetStringValue("sechen", "ns", ResearchingSectionNumber, "name")}'."));
            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Переток в исследуемом" +
                $" {ResearchingSectionNumber} сечении до утяжеления -" +
                $" {Math.Round(GetValue("sechen", "ns", ResearchingSectionNumber, "psech"), 0)} МВт."));

            RastrRetCode kod, kd;
            if (_rastr.ut_Param[ParamUt.UT_FORM_P] == 0) //формировать описание КВ
            {
                _rastr.Tables.Item("ut_common").Cols.Item("tip").Z[0] = 0; //тип утяжеления - стандартный
                _rastr.ut_FormControl(); //формирует таблицу описаний контролируемых величин
                _rastr.ClearControl(); //инициализировать таблицу значений контролируемых величин
                kod = _rastr.step_ut("i"); //"i" – инициализировать значения параметров утяжеления (шаг в этом случае не выполняется)
                if (kod == 0)
                {
                    do
                    {
                        // Переток до следующего шага по траектории 
                        double powerInSection = Math.Round(GetValue("sechen", "ns", ResearchingSectionNumber, "psech"), 0);

                        if(scnFileNames.Count == 0) //если закончились сценарии для расчёта, то завершаем работу алгоритма
                        {
                            Message?.Invoke(new object(), new EventProvider(MessageType.Info,
                                $"Расчёт переходных процессов по всем сценариям успешно завершён на {stepCounter} шаге утяжеления. "));
                            return;
                        }

                        foreach(string scn in scnFileNames)
                        {
                            try
                            {
                                LoadFile(scn, shablonScn);
                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Запущен расчёт переходного процесса по сценарию '{scn}'."));
                                FWDynamic FWDynamic = _rastr.FWDynamic();

                                FWDynamic.RunEMSmode();

                                switch (FWDynamic.SyncLossCause)
                                {
                                    case DFWSyncLossCause.SYNC_LOSS_NONE:
                                        {
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, "Потери синхронизма не выявлено."));
                                            break;
                                        }
                                        
                                    case DFWSyncLossCause.SYNC_LOSS_COA:
                                        {
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info,
                                            $"Выявлено превышение угла по сопротивлению генератора значения 180° в {FWDynamic.TimeReached} c."));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, FWDynamic.ResultMessage));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Динамическая устойчивость" +
                                                $" нарушается при перетоке в сечении, равном {powerInSection} МВт."));

                                            if (stepCounter != 0) //если мы уже сделали сколько-то шагов, можем вычислить Рпред
                                            {
                                                //мощный говнокод, который считает предельный по ДУ переток
                                                double incrementSum = 0; //сумма приращений генераторов.

                                                for (int i = 0; i < researchingPlantGenerators.Count; i++)
                                                {
                                                    incrementSum += GetValue("ut_node", "ny", researchingPlantGenerators[i], "pg");
                                                }
                                                powerInSectionWhenStabilityIsOK = powerInSection - incrementSum;

                                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Предельный по " +
                                                    $"динамической устойчивости переток составил {powerInSectionWhenStabilityIsOK} МВт."));
                                            }
                                            else
                                            {
                                                Message?.Invoke(new object(), new EventProvider(MessageType.Warning,
                                                    "Динамическая устойчивость нарушается даже при минимальной загрузке генераторов."));
                                            }
                                            scnFileNames.Remove(scn); //удаляем этот сценарий, потому что он больше не нужен - предел по ДУ найден.
                                            break;
                                        }
                                        
                                    case DFWSyncLossCause.SYNC_LOSS_BRANCHANGLE:
                                        {
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info,
                                            $"Выявлено превышение угла по ветви значения 180° в {FWDynamic.TimeReached} c."));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, FWDynamic.ResultMessage));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Динамическая устойчивость" +
                                                $" нарушается при перетоке в сечении, равном {powerInSection} МВт."));

                                            if (stepCounter != 0)
                                            {
                                                //мощный говнокод, который считает предельный по ДУ переток
                                                double incrementSum = 0; //сумма приращений генераторов.

                                                for (int i = 0; i < researchingPlantGenerators.Count; i++)
                                                {
                                                    incrementSum += GetValue("ut_node", "ny", researchingPlantGenerators[i], "pg");
                                                }
                                                powerInSectionWhenStabilityIsOK = powerInSection - incrementSum;

                                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Предельный по " +
                                                    $"динамической устойчивости переток составил {powerInSectionWhenStabilityIsOK} МВт."));
                                            }
                                            else
                                            {
                                                Message?.Invoke(new object(), new EventProvider(MessageType.Warning,
                                                    "Динамическая устойчивость нарушается даже при минимальной загрузке генераторов."));
                                            }
                                            scnFileNames.Remove(scn); //удаляем этот сценарий, потому что он больше не нужен - предел по ДУ найден.
                                            break;
                                        }
                                        
                                    case DFWSyncLossCause.SYNC_LOSS_OVERSPEED:
                                        {
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info,
                                            $"Выявлено превышение допустимой скорости вращения генератора в {FWDynamic.TimeReached} c."));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, FWDynamic.ResultMessage));
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Динамическая устойчивость" +
                                                $" нарушается при перетоке в сечении, равном {powerInSection} МВт."));

                                            if (stepCounter != 0)
                                            {
                                                //мощный говнокод, который считает предельный по ДУ переток
                                                double incrementSum = 0; //сумма приращений генераторов.

                                                for (int i = 0; i < researchingPlantGenerators.Count; i++)
                                                {
                                                    incrementSum += GetValue("ut_node", "ny", researchingPlantGenerators[i], "pg");
                                                }
                                                powerInSectionWhenStabilityIsOK = powerInSection - incrementSum;

                                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Предельный по " +
                                                    $"динамической устойчивости переток составил {powerInSectionWhenStabilityIsOK} МВт."));
                                            }
                                            else
                                            {
                                                Message?.Invoke(new object(), new EventProvider(MessageType.Warning,
                                                    "Динамическая устойчивость нарушается даже при минимальной загрузке генераторов."));
                                            }
                                            scnFileNames.Remove(scn); //удаляем этот сценарий, потому что он больше не нужен - предел по ДУ найден.
                                            break;
                                        }
                                }
                           }
                            catch (Exception ex)
                            {
                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Ошибка! {ex.Message}"));
                                return;
                            }
                        }

                        Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Расчёт переходных процессов на шаге {stepCounter+1} окончен."));

                        //проверка, не дошли ли генераторы до максимума своих регулировочных способностей
                        for (int j = 0; j < researchingPlantGenerators.Count; j++)
                        {
                            double powerOfGen = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "P");
                            double powerOfGenMax = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "Pmax");

                            if (powerOfGen >= powerOfGenMax)
                            {
                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, "Расчёт окончен. " +
                                    "Генераторы достигли предельной загрузки. Расчёт окончен."));
                                return;
                            }
                        }

                        // шаг утяжеления
                        kd = _rastr.step_ut("z");
                        if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0))
                            || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            _rastr.AddControl(-1, ""); //Добавить строку в таблицу значений контролируемых величин
                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Выполняется {stepCounter+1} шаг утяжеления..."));
                            stepCounter++;
                        }
                        // шаг утяжеления

                        foreach(var factor in factorList)
                        {
                            switch (factor)
                            {
                                case SectionFactor _:
                                    {
                                        factor.CurrentValue = GetValue("sechen", "ns", factor.NumberFromRastr, "psech");

                                        if (InfluentFactorBase.IsInDiapasone(factor) == false)
                                        {
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Warning, $"Влияющий фактор {factor.FactorType} " +
                                                $"c номером {factor.NumberFromRastr} вышел за границу диапазона."));
                                            do
                                            {
                                                //factor.CurrentValue = GetValue("sechen", "ns", factor.NumberFromRastr, "psech");
                                                StepBack();
                                                FileInfo fileInfo = new FileInfo(rstFileName);
                                                rstFileName = $@"{fileInfo.DirectoryName}\{DateTime.Now.ToString().Replace(":", "-")}{fileInfo.Extension}";
                                                SaveFile(rstFileName, shablonRst);
                                                LoadFile(rstFileName, shablonRst);

                                                SectionFactor.CorrectTrajectory(factor);

                                                iteration++;

                                                if (iteration > maxIteration)
                                                {
                                                    Message?.Invoke(new object(), new EventProvider(MessageType.Error, "Расчёт остановлен. Коррекция траектории утяжеления " +
                                                        "по заданным исходным данным невозможна. Попробуйте ещё раз."));
                                                    return;
                                                }

                                                LoadFile(rstFileName, shablonRst);

                                                RastrRetCode kd2;
                                                // шаг утяжеления
                                                kd2 = _rastr.step_ut("z");
                                                if (((kd2 == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0))
                                                    || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                                                {
                                                    _rastr.AddControl(-1, ""); //Добавить строку в таблицу значений контролируемых величин
                                                }

                                                factor.CurrentValue = GetValue("sechen", "ns", factor.NumberFromRastr, "psech");
                                            }
                                            while (InfluentFactorBase.IsInDiapasone(factor) == false);
                                            //StepBack();
                                            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Влияющий фактор {factor.FactorType} " +
                                                $"c номером {factor.NumberFromRastr} находится в заданном диапазоне."));
                                            break;
                                        }
                                        else break;
                                    }
                                case VoltageFactor _:
                                {
                                    factor.CurrentValue = GetValue("node", "ny", factor.NumberFromRastr, "vras");

                                    if(InfluentFactorBase.IsInDiapasone(factor) == false)
                                    {
                                            VoltageFactor.CorrectVoltage(researchingPlantGenerators, factor);
                                            Regime();
                                            factor.CurrentValue = GetValue("node", "ny", factor.NumberFromRastr, "vras");
                                            iteration++;

                                            if (iteration > maxIteration)
                                            {
                                                Message?.Invoke(new object(), new EventProvider(MessageType.Error, "Расчёт остановлен. Коррекция траектории утяжеления " +
                                                    "по заданным исходным данным невозможна. Попробуйте ещё раз."));
                                                return;
                                            }
                                            break;
                                    }
                                    else break;
                                }
                                
                            }
                        }

                        //если все факторы попали в диапазон, всё хорошо, шагаем дальше

                        //если генераторы дошли до максимума, останавливается расчёт
                        for (int j = 0; j < researchingPlantGenerators.Count; j++)
                        {
                            double powerOfGen = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "P");
                            double powerOfGenMax = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "Pmax");

                            if (powerOfGen >= powerOfGenMax)
                            {
                                Message?.Invoke(new object(), new EventProvider(MessageType.Info, "Расчёт окончен. " +
                                    "Генераторы достигли предельной загрузки. Расчёт окончен."));
                                return;
                            }
                        }
                    }
                    while (kd == 0);
                }
            }

            foreach (var factor in factorList)
            {
                if(InfluentFactorBase.IsInDiapasone(factor) == false)
                {
                    Message?.Invoke(new object(), new EventProvider(MessageType.Error, $"Поддержание в заданном диапазоне влияющего " +
                        $"фактора {factor.FactorType} с номером {factor.NumberFromRastr}" +
                        $" невозможно при заданных исходных данных. Проверьте режим, траекторию и корректность заданных границ диапазона."));
                    return;
                }
            }

            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"***Превышено предельное число итераций!***"));
            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Расчёт успешно завершён на {stepCounter} шаге утяжеления."));
            Message?.Invoke(new object(), new EventProvider(MessageType.Info, $"Величина перетока в исследуемом" +
                $" сечении {ResearchingSectionNumber} составляет" +
                $" {Math.Round(GetValue("sechen", "ns", ResearchingSectionNumber, "psech"), 0)} МВт."));
        }

        /// <summary>
        /// Заполняет список номерами узлов/сечений из загруженного файла
        /// </summary>
        public static List<int> FillListOfNumbersFromRastr(string tableName, string parameterName)
        {
            List<int> ListOfNumbersFromRastr = new List<int>();

            try
            {
                ITable table = _rastr.Tables.Item(tableName);
                ICol column = table.Cols.Item(parameterName);

                for (int index = 0; index < table.Count; index++)
                {
                    ListOfNumbersFromRastr.Add(column.get_ZN(index));
                }

                return ListOfNumbersFromRastr;
            }
            catch(Exception exeption)
            {
                throw new Exception(exeption.Message);
            }
        }

        /// <summary>
        /// Сохранение данных из таблицы DataTable по шаблону в 
        /// файл формата ut2 (траектория утяжеления)
        /// </summary>
        public static void SaveToUt2FromDataGrid(DataTable dataTable)
        {
            string shablon = @"../../Resources/траектория утяжеления.ut2";

            CreateFile(shablon);

            ITable table = _rastr.Tables.Item("ut_node");

            for (int j = 0; j < dataTable.Rows.Count; j++)
            {
                table.AddRow();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    ICol column = table.Cols.Item(dataTable.Columns[i].ColumnName);
                    column.set_Z(j, dataTable.Rows[j][i]);
                }
            }
        }

        /// <summary>
        /// Записать загруженный файл с траекторией
        /// утяжеления в DataTable
        /// </summary>
        public static void LoadUt2ToDataGrid(DataTable dataTable)
        {
            ITable table = _rastr.Tables.Item("ut_node");

            for (int i = 0; i < table.Count; i++)
            {
                dataTable.Rows.Add();

                for (int k = 0; k < dataTable.Columns.Count; k++)
                {
                    for (int j = 0; j < table.Cols.Count; j++)
                    {
                        ICol column = table.Cols.Item(j);

                        if (column.Name == dataTable.Columns[k].ColumnName)
                        {
                            dataTable.Rows[i][k] = column.get_Z(i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Шаг назад по траектории
        /// </summary>
        public static void StepBack()
        {
            ITable table = _rastr.Tables.Item("ut_common");
            ICol columnItem = table.Cols.Item("kfc"); //шаг утяжеления

            int index = table.Count - 1; //индекс - самая последняя строка
            double step = columnItem.get_ZN(index);

            columnItem.set_Z(index, -step);

            RastrRetCode kd;
            // шаг утяжеления
            kd = _rastr.step_ut("z");
            if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0))
                || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
            {
                _rastr.AddControl(-1, ""); //Добавить строку в таблицу значений контролируемых величин
            }

            columnItem.set_Z(index, step);
        }

        /// <summary>
        /// Задать булевое значение
        /// </summary>
        public static void SetBool(string tableName, string parameterName, int number, 
            string chosenParameter, bool value)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            columnItem.set_ZN(index, value);
        }

        /// <summary>
        /// Первичная проверка для всех факторов-сечений:
        /// Если реакции нет, тогда фактору присваивается Реакция = 0
        /// Если реакция есть, она рассчитывается для этого сечения-ВФ
        /// </summary>
        public static void PrimaryCheckForReactionOfSection(BindingList<InfluentFactorBase> factorList, List<int> researchingPlantGenerators, string rstFileName)
        {
            string shablonRst = @"../../Resources/динамика.rst";

            ITable tableForIncrement = _rastr.Tables.Item("ut_node");
            ICol columnForStatement = tableForIncrement.Cols.Item("sta");

            //Приращения для всех сечений-факторов выставляем равным нулю (иначе говоря, их строки отключается)
            foreach (var factor in factorList)
            {
                if (factor is SectionFactor) //если ВФ это сечение
                {
                    for (int j = 0; j < ((SectionFactor)factor).RegulatingGeneratorsList.Count; j++)
                    {
                        SetBool("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[j], "sta", true);
                    }
                }
            }

            foreach (var factor in factorList)
            {
                if (factor is SectionFactor) //если ВФ это сечение
                {
                    double initialSectionPower = Math.Round(GetValue("sechen", "ns", factor.NumberFromRastr, "psech"), 0); //1772

                    //Расчёт шага утяжеления только основными ГГ (после первого шага цикл прерывается)
                    if (_rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
                    {
                        _rastr.Tables.Item("ut_common").Cols.Item("tip").Z[0] = 0;
                        _rastr.ut_FormControl();
                        _rastr.ClearControl();
                        RastrRetCode kod = _rastr.step_ut("i");
                        if (kod == 0)
                        {
                            RastrRetCode kd;
                            do
                            {
                                //шаг утяжеления
                                kd = _rastr.step_ut("z");
                                if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0)) || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                                {
                                    _rastr.AddControl(-1, "");
                                }
                                //шаг утяжеления

                                double sectionPowerAfterStep = Math.Round(GetValue("sechen", "ns", factor.NumberFromRastr, "psech"), 0); //значение перетока после шага утяжеления

                                StepBack(); //шагаем назад (возвращаемся к исходному режиму)

                                if (sectionPowerAfterStep == initialSectionPower) //если переток НЕ изменился после шага утяжеления, то приращения остаются равными нулю
                                {
                                    ((SectionFactor)factor).Reaction = 0;
                                    return;
                                }
                                else //если переток меняется, значит есть зависимость -> нужно рассчитать приращение
                                {
                                    ((SectionFactor)factor).Reaction = sectionPowerAfterStep - initialSectionPower; //расчёт реакции 1802 - 1772 = 32

                                    //Обратно включаем номера влияющих генераторов в таблице приращений
                                    for (int i = 0; i < ((SectionFactor)factor).RegulatingGeneratorsList.Count; i++) 
                                    {
                                        SetBool("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[i], "sta", false);
                                    }

                                    //Выключаем номера ГГ исследуемой станции
                                    for (int i = 0; i < researchingPlantGenerators.Count; i++)
                                    {
                                        SetBool("ut_node", "ny", researchingPlantGenerators[i], "sta", true);
                                    }

                                    if (((SectionFactor)factor).Reaction > 0) //если реакция положительная, установить приращение влияющим ГГ со знаком "-"
                                    {
                                        for (int i = 0; i < ((SectionFactor)factor).RegulatingGeneratorsList.Count; i++)
                                        {
                                            SetValue("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[i], "pg", -1);
                                        }
                                    }
                                    else if(((SectionFactor)factor).Reaction < 0) // если реакция отрицательная, установить приращение влияющим ГГ со знаком "+"
                                    {
                                        for (int i = 0; i < ((SectionFactor)factor).RegulatingGeneratorsList.Count; i++)
                                        {
                                            SetValue("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[i], "pg", 1);
                                        }
                                    }
                                }
                                break; //прерываем после одного шага
                            }
                            while (kd == 0);
                        }
                    }

                    //Траектория готова. Делаем по ней шаг, чтобы рассчитать коэффициент влияния влияющих ГГ на сечение-ВФ

                    //double powerFlowBeforeStep;
                    double powerFlowAfterStep;

                    //Загружаем исходный режим

                    LoadFile(rstFileName, shablonRst);
                   
                    if (_rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
                    {
                        //_rastr.Tables.Item("ut_common").Cols.Item("tip").Z[0] = 0;
                        _rastr.ut_FormControl();
                        _rastr.ClearControl();
                        RastrRetCode kod = _rastr.step_ut("i");
                        if (kod == 0)
                        {
                            RastrRetCode kd;
                            do
                            {
                                kd = _rastr.step_ut("z");
                                if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0)) || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                                {
                                    _rastr.AddControl(-1, "");
                                }
                                // Шаг выполнен. Определяем реакцию

                                powerFlowAfterStep = GetValue("sechen", "ns", factor.NumberFromRastr, "psech"); //фиксируем переток ПОСЛЕ почему 1796?
                                StepBack();

                                double InfluentCoeff = ((powerFlowAfterStep - initialSectionPower) / ((SectionFactor)factor).RegulatingGeneratorsList.Count); // -8 / 9 = -0,89
                                double compensationPower = ((SectionFactor)factor).Reaction / InfluentCoeff; // 32 / -0,89 = -35,9
                                double increment = compensationPower / ((SectionFactor)factor).RegulatingGeneratorsList.Count; // -35,9 / 9 = -4

                                // присваиваем приращение в таблице траектории

                                for (int i = 0; i < ((SectionFactor)factor).RegulatingGeneratorsList.Count; i++) //для каждого генератора данного сечения
                                {
                                    SetValue("ut_node", "ny", ((SectionFactor)factor).RegulatingGeneratorsList[i], "pg", increment); //приращение генерации пересчитанное
                                }
                                break;
                            }
                            while (kd == 0);
                        }
                    }
                }
            }

            for(int i = 0; i < tableForIncrement.Count; i++)
            {
                columnForStatement.set_Z(i, false);
            }

            //Опять исходный режим

            LoadFile(rstFileName, shablonRst);
        }
    }
}
