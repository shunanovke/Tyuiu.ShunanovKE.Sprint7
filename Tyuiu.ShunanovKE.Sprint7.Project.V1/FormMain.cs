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
using System.IO;


namespace Tyuiu.ShunanovKE.Sprint7.Project.V1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialogFile_SKE.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
            saveFileDialogFile_SKE.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";

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


        DataService ds = new DataService();
        int rows;


        //OtherForms
        private void buttonAbout_SKE_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonAboutProgram_SKE_Click(object sender, EventArgs e)
        {
            FormForUser formForUser = new FormForUser();
            formForUser.ShowDialog();
        }


        //File
        private void buttonOpenFile_SKE_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain formmain = new FormMain();
                openFileDialogFile_SKE.ShowDialog();
                string path = openFileDialogFile_SKE.FileName;
                string[,] array = ds.GetMatrix(path);
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
                buttonSaveFile_SKE.Enabled = true;

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

        private void buttonSaveFile_SKE_Click(object sender, EventArgs e)
        {
            saveFileDialogFile_SKE.FileName = "OutPutFileProjectV1.csv";
            saveFileDialogFile_SKE.InitialDirectory = Directory.GetCurrentDirectory();
            string outPath = saveFileDialogFile_SKE.FileName;

            saveFileDialogFile_SKE.ShowDialog();
            string str = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (j != 6 - 1)
                    {
                        str += dataGridViewFile_SKE.Rows[i].Cells[j].Value + ";";
                    }
                    else
                    {
                        str += dataGridViewFile_SKE.Rows[i].Cells[j].Value;
                    }
                }
                File.AppendAllText(outPath, str + Environment.NewLine);
                str = "";
            }
        }




        //Editing
        private void buttonAdd_SKE_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxAddRate_SKE.Text) >= 1 && Convert.ToDouble(textBoxAddRate_SKE.Text) <= 5 &&
                    (Convert.ToInt32(textBoxAddClose_SKE.Text.Split(':')[0]) < 24) && ((Convert.ToInt32(textBoxAddClose_SKE.Text.Split(':')[1]) < 60)) &&
                    (Convert.ToInt32(textBoxAddOpen_SKE.Text.Split(':')[0]) < 24) && ((Convert.ToInt32(textBoxAddOpen_SKE.Text.Split(':')[1]) < 60)) &&
                    textBoxAddPhone_SKE.Text.Length == 11 && textBoxAddName_SKE.Text.Length != 0 &&
                    textBoxAddOpen_SKE.Text.Split(':')[0].Length <= 2 && textBoxAddOpen_SKE.Text.Split(':')[1].Length == 2 &&
                    textBoxAddClose_SKE.Text.Split(':')[0].Length <= 2 && textBoxAddClose_SKE.Text.Split(':')[1].Length == 2)
                {
                    dataGridViewFile_SKE.Rows.Add((rows + 1).ToString(), textBoxAddName_SKE.Text, textBoxAddOpen_SKE.Text,
                    textBoxAddClose_SKE.Text, textBoxAddPhone_SKE.Text, textBoxAddRate_SKE.Text);
                    rows++;

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
                else MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string num = textBoxDeleteNum_SKE.Text;
                for (int i = 0; i < rows; i++)
                {
                    if (dataGridViewFile_SKE.Rows[i].Cells[0].Value.ToString() == num)
                    {
                        dataGridViewFile_SKE.Rows.Remove(dataGridViewFile_SKE.Rows[i]);
                        rows--;
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    if (Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value) > Convert.ToInt32(num))
                    {
                        dataGridViewFile_SKE.Rows[i].Cells[0].Value = Convert.ToString(Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value) - 1);
                    }
                }
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

            }
        }



        //Sorting
        private void buttonSortNum_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortNum(temp_array);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }
        }

        private void buttonSortRate_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortRate(ds.SortNum(temp_array));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }

            //Graph
            this.chartGraph_SKE.ChartAreas[0].AxisX.Title = "Номер автомастерской";
            this.chartGraph_SKE.ChartAreas[0].AxisY.Title = "Рейтинг";
            chartGraph_SKE.Series[0].Points.Clear();
            for (int i = 0; i < rows; i++)
            {
                chartGraph_SKE.Series[0].Points.AddXY(Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value), Convert.ToDouble(dataGridViewFile_SKE.Rows[i].Cells[5].Value));
            }
        }

        private void buttonSortTime_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortTimeDuration(ds.SortNum(temp_array));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }
            //Graph
            this.chartGraph_SKE.ChartAreas[0].AxisX.Title = "Номер автомастерской";
            this.chartGraph_SKE.ChartAreas[0].AxisY.Title = "Время работы (ч.)";
            chartGraph_SKE.Series[0].Points.Clear();
            double dur;
            int cl, op;
            for (int i = 0; i < rows; i++)
            {
                cl = Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[3].Value.ToString().Split(':')[0]) * 60 + 
                     Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[3].Value.ToString().Split(':')[1]);
                op = Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[2].Value.ToString().Split(':')[0]) * 60 +
                     Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[2].Value.ToString().Split(':')[1]);
                dur = Convert.ToDouble(cl - op) / 60;
                chartGraph_SKE.Series[0].Points.AddXY(Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value), dur);
            }
        }

        private void buttonSortOpen_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortTimeOpen(ds.SortNum(temp_array));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }
            //Graph
            this.chartGraph_SKE.ChartAreas[0].AxisX.Title = "Номер автомастерской";
            this.chartGraph_SKE.ChartAreas[0].AxisY.Title = "Время открытия (ч.)";
            chartGraph_SKE.Series[0].Points.Clear();
            double dur;
            int op;
            for (int i = 0; i < rows; i++)
            {
                op = Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[2].Value.ToString().Split(':')[0]) * 60 +
                     Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[2].Value.ToString().Split(':')[1]);
                dur = Convert.ToDouble(op) / 60;
                chartGraph_SKE.Series[0].Points.AddXY(Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value), dur);
            }
        }

        private void buttonSortClose_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortTimeClose(ds.SortNum(temp_array));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }
            //Graph
            this.chartGraph_SKE.ChartAreas[0].AxisX.Title = "Номер автомастерской";
            this.chartGraph_SKE.ChartAreas[0].AxisY.Title = "Время закрытия (ч.)";
            chartGraph_SKE.Series[0].Points.Clear();
            double dur;
            int cl;
            for (int i = 0; i < rows; i++)
            {
                cl = Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[3].Value.ToString().Split(':')[0]) * 60 +
                     Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[3].Value.ToString().Split(':')[1]);
                dur = Convert.ToDouble(cl) / 60;
                chartGraph_SKE.Series[0].Points.AddXY(Convert.ToInt32(dataGridViewFile_SKE.Rows[i].Cells[0].Value), dur);
            }
        }

        private void buttonSortName_SKE_Click(object sender, EventArgs e)
        {
            string[,] temp_array = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    temp_array[i, j] = dataGridViewFile_SKE.Rows[i].Cells[j].Value.ToString();
                }
            }
            string[,] new_array = ds.SortName(ds.SortNum(temp_array));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    dataGridViewFile_SKE.Rows[i].Cells[j].Value = new_array[i, j];
                }
            }
        }



        //Keypress
        private void textBoxAddOpen_SKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != ':') && (e.KeyChar != 8)) || ((textBoxAddOpen_SKE.Text.Length > 4) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddRate_SKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != ',') && (e.KeyChar != 8)) || ((textBoxAddRate_SKE.Text.Length > 2)) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddPhone_SKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != 8)) || ((textBoxAddPhone_SKE.Text.Length > 10) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddClose_SKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar != ':') && (e.KeyChar != 8)) || ((textBoxAddClose_SKE.Text.Length > 4) && (e.KeyChar != 8)))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddName_SKE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || (e.KeyChar > 90 && e.KeyChar < 97) || e.KeyChar > 122) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

    }
}
