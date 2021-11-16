using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Загрузка файла в рабочую область 
        /// </summary>
        public void LoadFile (string filePath, string shablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, filePath, shablon);
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        public static void SaveFile(string fileName, string shablon)
        {
            _rastr.Save(fileName, shablon);
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

        /// <summary>
        /// Рассчитывает режим
        /// </summary>
        /// <returns> Возвращает true - расчет завершен успешно,
        /// false - аварийное завершение расчета</returns>
        public bool IsRegimeOK()
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
        public void Regime()
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
        /// Алгоритм утяжеления
        /// </summary>
        public static void Worsening(BindingList<InfluentFactorBase> factorList, int maxIteration,
            List<int> researchingPlantGenerators, RastrSupplier rastrSupplier, 
            ListBox protocolListBox, DataGridView dataGridView, int iteration, int ResearchingSectionNumber)
        {
            protocolListBox.Items.Add($"Величина перетока в исследуемом" +
                        $" {ResearchingSectionNumber} сечении до утяжеления - " +
                        $" {Math.Round(GetValue("sechen", "ns", ResearchingSectionNumber, "psech"), 0)} МВт.");

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
                        //проверка, не дошли ли генераторы до максимума своих регулировочных способностей
                        for (int j = 0; j < researchingPlantGenerators.Count; j++)
                        {
                            double powerOfGen = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "P");
                            double powerOfGenMax = GetValue("Generator", "Node",
                                researchingPlantGenerators[j], "Pmax");

                            if (powerOfGen >= powerOfGenMax)
                            {
                                protocolListBox.Items.Add("Расчёт окончен. " +
                                    "Генераторы достигли предельной загрузки, режим не разошёлся.");
                                dataGridView.Refresh();
                                return;
                            }
                        }
                        
                        //проверка, не разошёлся ли режим
                        if (!rastrSupplier.IsRegimeOK())
                        {
                            protocolListBox.Items.Add("Аварийное завершение расчёта!");
                            dataGridView.Refresh();
                            return;
                        }

                        // шаг утяжеления
                        kd = _rastr.step_ut("z");
                        if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0))
                            || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            _rastr.AddControl(-1, ""); //Добавить строку в таблицу значений контролируемых величин
                        }
                        // шаг утяжеления

                        foreach(var factor in factorList)
                        {
                            switch (factor)
                            {
                                case VoltageFactor _:
                                {
                                    factor.CurrentValue = GetValue("node", "ny", factor.NumberFromRastr, "vras");

                                    switch(InfluentFactorBase.IsInDiapasone(factor))
                                    {
                                        case true:
                                        {
                                            break;
                                        }
                                        case false:
                                        {
                                            VoltageFactor.CorrectVoltage(researchingPlantGenerators, factor);
                                            rastrSupplier.Regime();
                                            factor.CurrentValue = GetValue("node", "ny", factor.NumberFromRastr, "vras");
                                            break;
                                        }
                                    }
                                    break;
                                }
                                case SectionFactor _:
                                {
                                    // ту би континьюд
                                    break;
                                }
                                case LoadFactor _:
                                {
                                    // ту би континьюд
                                    break;
                                }
                            }
                        }
                        
                        iteration = iteration + 1;

                        if(iteration > maxIteration)
                        {
                            protocolListBox.Items.Add("Расчёт остановлен. Коррекция траектории утяжеления " +
                                "по заданным исходным данным невозможна. Попробуйте ещё раз.");
                            return;
                        }
                        //если все факторы попали в диапазон, всё хорошо, шагаем дальше
                    }
                    while (kd == 0);

                    protocolListBox.Items.Add($"Превышено предельное число итераций!");
                    protocolListBox.Items.Add($"Расчёт успешно завершён на {iteration} шаге утяжеления.");
                    protocolListBox.Items.Add($"Величина перетока в исследуемом" +
                        $" {ResearchingSectionNumber} сечении составляет" +
                        $" {Math.Round(GetValue("sechen", "ns", ResearchingSectionNumber, "psech"), 0)} МВт.");

                }
            }
        }

        /// <summary>
        /// Заполняет список номерами узлов/сечений из загруженного файла
        /// </summary>
        public static void FillListOfNumbersFromRastr(List<int> numbersFromRastr, 
            string tableName, string parameterName)
        {
            try
            {
                ITable table = _rastr.Tables.Item(tableName);
                ICol column = table.Cols.Item(parameterName);

                for (int index = 0; index < table.Count; index++)
                {
                    numbersFromRastr.Add(column.get_ZN(index));
                }
            }
            catch
            {

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
        private static void StepBack()
        {
            ITable table = _rastr.Tables.Item("ut_common");
            ICol columnItem = table.Cols.Item("kfc"); //шаг утяжеления

            int index = table.Count - 1; //индекс - самая последняя строка
            double step = columnItem.get_ZN(index);

            columnItem.set_Z(index, -step);
        }
    }
}
