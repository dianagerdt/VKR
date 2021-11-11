using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.ComponentModel;

namespace RustabBot_v1._0
{
    public class DataGridViewTools
    {
        /// <summary>
        /// Метод создания таблицы желаемого формата
        /// </summary>
        /// <param name="factors">Список факторов</param>
        /// <param name="dataGridView">Таблица с факторами</param>
        /// <summary>
        /// Метод создания таблицы 
        /// </summary>
        public static void CreateTableForFactors(BindingList<InfluentFactorBase> factors,
            DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = factors;
            dataGridView.Columns[0].HeaderText = "Тип фактора";
            dataGridView.Columns[1].HeaderText = "Номер";
            dataGridView.Columns[2].HeaderText = "Минимум";
            dataGridView.Columns[3].HeaderText = "Максимум";
            dataGridView.Columns[4].HeaderText = "Текущее значение";

            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;

            dataGridView.AutoSizeColumnsMode =
               DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ReadOnly = true;
        }

        
        public static void CreateTableForTrajectory(
            DataGridView dataGridView)
        {
            var columnGenerator = new DataGridViewColumn();
            var columnIncrement = new DataGridViewColumn();

            columnGenerator.HeaderText = "Генератор";
            columnGenerator.ReadOnly = true; //значение в этой колонке нельзя править
            columnGenerator.Name = "columnGenerator"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            columnGenerator.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            columnIncrement.HeaderText = "Приращение";
            columnIncrement.ReadOnly = false; //значение в этой колонке нельзя править
            columnIncrement.Name = "columnIncrement"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            columnIncrement.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            dataGridView.Columns.Add(columnGenerator);
            dataGridView.Columns.Add(columnIncrement);
            dataGridView.AllowUserToAddRows = false; //запрещаем пользователю самому добавлять строки
            dataGridView.RowHeadersVisible = false;

            dataGridView.AutoSizeColumnsMode =
               DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
