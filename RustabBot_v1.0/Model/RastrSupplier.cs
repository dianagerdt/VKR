using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

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
        public static bool Regime()
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
        public static void Worsening()
        {
            RastrRetCode kod, kd;
            if (_rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
            {
                _rastr.Tables.Item("ut_common").Cols.Item("tip").Z[0] = 0;
                _rastr.ut_FormControl();
                _rastr.ClearControl();
                kod = _rastr.step_ut("i");
                if (kod == 0)
                {
                    do
                    {
                        kd = _rastr.step_ut("z");
                        if (((kd == 0) && (_rastr.ut_Param[ParamUt.UT_ADD_P] == 0))
                            || _rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            _rastr.AddControl(-1, "");
                        }
                    }
                    while (kd == 0);
                }
            }
        }

        /// <summary>
        /// Заполняет список номерами узлов/сечений из загруженного файла
        /// </summary>
        public static void FillListOfNumbersFromRastr(List<int> numbersFromRastr, 
            string tableName, string parameterName)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol column = table.Cols.Item(parameterName);

            for(int index = 0; index < table.Count; index++)
            {
                numbersFromRastr.Add(column.get_ZN(index)); 
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

        /*public int HowManyRows()
        {
            int count = 0;
            ITable table = _rastr.Tables.Item("ut_node");
            for (int i = 0; i < table.Count; i++)
            {
                count++;
            }
            return count;
        }*/
    }
}
