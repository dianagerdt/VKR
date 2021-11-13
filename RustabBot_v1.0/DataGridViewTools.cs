using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.ComponentModel;
using System.Data;

namespace RustabBot_v1._0
{
    /// <summary>
    /// Класс для манипуляций с таблицами 
    /// </summary>
    public class DataGridViewTools
    {
        /// <summary>
        /// Метод создания таблицы желаемого формата
        /// </summary>
        /// <param name="factors">Список факторов</param>
        /// <param name="dataGridView">Таблица с факторами</param>
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
            dataGridView.Columns[5].Visible = false;

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

        /// <summary>
        /// Метод для создания таблицы для траектории утяжеления
        /// </summary>
        public static void CreateTableForTrajectory(
            DataGridView dataGridView)
        {
            DataTable dt = new DataTable("Trajectory");

            dt.Columns.Add("ny", typeof(int));
            dt.Columns.Add("pn", typeof(double));
            dt.Columns.Add("qn", typeof(double));
            dt.Columns.Add("tg", typeof(bool));
            dt.Columns.Add("pg", typeof(double));
            dt.Columns.Add("qg", typeof(double));

            dt.Columns[0].Caption = "Номер";
            dt.Columns[1].Caption = "dP";
            dt.Columns[2].Caption = "dQ";
            dt.Columns[3].Caption = "Tg";
            dt.Columns[4].Caption = "dP_ген";
            dt.Columns[5].Caption = "dQ_ген";

            DataColumn[] unique_cols =
            {
                dt.Columns["ny"],
            };

            dt.Constraints.Add(new UniqueConstraint(unique_cols));

            dataGridView.DataSource = dt;

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.HeaderText = dt.Columns[col.Name].Caption;
            }

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
