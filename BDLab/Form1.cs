using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDLab
{
    public partial class Form1 : Form
    {
        int i = 1;
        Random rnd = new Random();
        string fileName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[0].ValueType = typeof(int);
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].ValueType = typeof(string);
            dataGridView1.Columns[2].Name = "Course";
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].ValueType = typeof(int);
            dataGridView1.Columns[3].Name = "Average score";
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].ValueType = typeof(double);
            dataGridView1.Columns[4].Name = "Graduate";
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].ValueType = typeof(bool);
        }

        private void openBtn_Click(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Текстовый файл | *.txt; | Все файлы (*.*) | *.*";
            dialog.RestoreDirectory = true;
            dialog.DefaultExt = ".txt";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                Functions.saveDGV(fileName, dataGridView1);
            }
        }
    }
}
