using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.ShunanovKE.Sprint7.Project.V1.Lib;


namespace Tyuiu.ShunanovKE.Sprint7.Project.V1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialogFile_SKE.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
        }

        DataService ds = new DataService();
        string path;
        string[,] array;
        int rows;

        private void buttonAbout_SKE_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonOpenFile_SKE_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain formmain = new FormMain();
                openFileDialogFile_SKE.ShowDialog();
                path = openFileDialogFile_SKE.FileName;
                array = ds.GetMatrix(path);
                rows = array.GetUpperBound(0) + 1;
                dataGridViewFile_SKE.RowCount = rows;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        dataGridViewFile_SKE.Rows[i].Cells[j].Value = array[i, j];
                    }
                }
                buttonAdd_SKE.Enabled = true;
                buttonDelete_SKE.Enabled = true;
                buttonSortNum_SKE.Enabled = true;
                buttonSortClose_SKE.Enabled = true;
                buttonSortOpen_SKE.Enabled = true;
                buttonSortRate_SKE.Enabled = true;
                buttonSortTime_SKE.Enabled = true;
                buttonSortName_SKE.Enabled = true;

                //Stats
                double[] rates = new double[rows];
                int[] timeOpen = new int[rows];
                int[] timeClose = new int[rows];
                int[] timeDuration = new int[rows];
                string str;
                for (int i = 0; i < rows; i++)
                {
                    rates[i] = Convert.ToDouble(dataGridViewFile_SKE.Rows[i].Cells[5].Value);
                    str = Convert.ToString(dataGridViewFile_SKE.Rows[i].Cells[2].Value);
                    timeOpen[i] = Convert.ToInt32(str.Split(':')[0]) * 60 + Convert.ToInt32(str.Split(':')[1]);
                    str = Convert.ToString(dataGridViewFile_SKE.Rows[i].Cells[3].Value);
                    timeClose[i] = Convert.ToInt32(str.Split(':')[0]) * 60 + Convert.ToInt32(str.Split(':')[1]);
                    timeDuration[i] = timeClose[i] - timeOpen[i];
                }
                textBoxStatCnt_SKE.Text = Convert.ToString(rows);
                textBoxStatMaxRate_SKE.Text = Convert.ToString(rates.Max());
                textBoxStatMinRate_SKE.Text = Convert.ToString(rates.Min());
                textBoxStatAverageRate_SKE.Text = Convert.ToString(Math.Round(rates.Sum() / rows, 3));
                textBoxStatTimeOpen_SKE.Text = Convert.ToString(timeOpen.Min() / 60) + ":" + (timeOpen.Min() % 60).ToString("00");
                textBoxStatTimeClose_SKE.Text = Convert.ToString(timeClose.Max() / 60) + ":" + (timeClose.Max() % 60).ToString("00");
                textBoxStatTimeDuration_SKE.Text = Convert.ToString(timeDuration.Max() / 60) + ":" + (timeDuration.Max() % 60).ToString("00");

            }
            catch
            {
                MessageBox.Show("Выбран неверный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridViewFile_SKE.RowCount = 10;
            dataGridViewFile_SKE.ColumnCount = 6;
            dataGridViewFile_SKE.Columns[0].Width = 20;
            dataGridViewFile_SKE.Columns[1].Width = 320;
            dataGridViewFile_SKE.Columns[2].Width = 110;
            dataGridViewFile_SKE.Columns[3].Width = 110;
            dataGridViewFile_SKE.Columns[4].Width = 120;
            dataGridViewFile_SKE.Columns[5].Width = 100;
        }

        private void buttonAdd_SKE_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewFile_SKE.RowCount += 1;
                string[] a = {dataGridViewFile_SKE.Rows[rows].Cells[0].Value.ToString(),
                              dataGridViewFile_SKE.Rows[rows].Cells[1].Value.ToString(),
                              dataGridViewFile_SKE.Rows[rows].Cells[2].Value.ToString(),
                              dataGridViewFile_SKE.Rows[rows].Cells[3].Value.ToString(),
                              dataGridViewFile_SKE.Rows[rows].Cells[4].Value.ToString(),
                              dataGridViewFile_SKE.Rows[rows].Cells[5].Value.ToString() };
                dataGridViewFile_SKE.Rows[rows].Cells[0].Value = rows + 1;
                dataGridViewFile_SKE.Rows[rows].Cells[1].Value = textBoxAddName_SKE.Text;
                dataGridViewFile_SKE.Rows[rows].Cells[2].Value = textBoxAddOpen_SKE.Text;
                dataGridViewFile_SKE.Rows[rows].Cells[3].Value = textBoxAddClose_SKE.Text;
                dataGridViewFile_SKE.Rows[rows].Cells[4].Value = textBoxAddPhone_SKE.Text;
                dataGridViewFile_SKE.Rows[rows].Cells[5].Value = textBoxAddRate_SKE.Text;
                for (int i = 0; i < 6; i++)
                {
                    dataGridViewFile_SKE.Rows[rows - 1].Cells[i].Value = a[i];
                }
                rows++;
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_SKE_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBoxDeleteNum_SKE);
                
            }
            catch
            {

            }
        }

        private void buttonSortNum_SKE_Click(object sender, EventArgs e)
        {

        }

    }
}
