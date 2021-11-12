using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

namespace Model
{
    // Связь с растром
    public class RastrSupplier
    {
        private static Rastr _rastr = new Rastr();

        public void LoadFile (string filePath, string shablon)
        {
            _rastr.Load(RG_KOD.RG_REPL, filePath, shablon);
        }

        public static void SaveFile(string fileName, string shablon)
        {
            _rastr.Save(fileName, shablon);
        }

        public static void CreateFile(string shablon)
        {
            _rastr.NewFile(shablon);
        }

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

            throw new Exception($"Узел с номером {number} не найден.");
        }

        public static double GetValue(string tableName, string parameterName, int number, string chosenParameter)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            return columnItem.get_ZN(index);
        }

        /// <summary>
        /// Рассчитывает режим
        /// </summary>
        /// <returns> Возвращает 
        /// true - расчет завершен успешно,
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

        public static void SetValue(string tableName, string parameterName, int number, string chosenParameter, double value)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol columnItem = table.Cols.Item(chosenParameter);

            int index = GetIndexByNumber(tableName, parameterName, number);
            columnItem.set_ZN(index, value);
        }

        public static void Worsening (Rastr rastr)
        {
            RastrRetCode kod, kd;
            if (rastr.ut_Param[ParamUt.UT_FORM_P] == 0)
            {
                rastr.Tables.Item("ut_common").Cols.Item("tip").Z[0] = 0;
                rastr.ut_FormControl();
                rastr.ClearControl();
                kod = rastr.step_ut("i");
                if (kod == 0)
                {
                    do
                    {
                        kd = rastr.step_ut("z");
                        if (((kd == 0) && (rastr.ut_Param[ParamUt.UT_ADD_P] == 0)) || rastr.ut_Param[ParamUt.UT_TIP] == 1)
                        {
                            rastr.AddControl(-1, "");
                        }
                    }
                    while (kd == 0);
                }
            }
        }

        //Возвращает список с номерами сечений/узлов из файла
        public static void FillListOfNumbersFromRastr(List<int> numbersFromRastr, string tableName, string parameterName)
        {
            ITable table = _rastr.Tables.Item(tableName);
            ICol column = table.Cols.Item(parameterName);

            for(int index = 0; index < table.Count; index++)
            {
                numbersFromRastr.Add(column.get_ZN(index)); 
            }
        }

        // Сохраняет данные из таблицы в файл траектории утяжеления
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

        public static void LoadUt2ToDataGrid(DataTable dataTable)
        {
            ITable table = _rastr.Tables.Item("ut_node");

            
        }
    }
}
