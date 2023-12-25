using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tyuiu.ShunanovKE.Sprint7.Project.V1.Lib
{
    public class DataService
    {
        public string[,] GetMatrix(string path)
        {
            string fileData = File.ReadAllText(path);
            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int cols = lines[0].Split(';').Length;
            string[,] mtrx = new string[rows, cols];
            string[] line;
            for (int i = 0; i < rows; i++)
            {
                line = lines[i].Split(';');
                for (int j = 0; j < cols; j++)
                {
                    mtrx[i, j] = line[j];
                }
            }
            return mtrx;
        }

        public string[,] SortNum(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            int[] index = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                index[i] = Convert.ToInt32(array[i, 0]);
            }
            string[,] res = new string[rows, 6];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    res[index[i] - 1, j] = array[i, j];
                }
            }
            return res;
        }

        public string[,] SortRate(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            string[,] res = array;
            double max;
            string temporary;
            for (int i = 0; i < rows - 1; i++)
            {
                max = Convert.ToDouble(res[i, 5]);
                for (int j = i + 1; j < rows; j++)
                {
                    if (max < Convert.ToDouble(res[j, 5]))
                    {
                        max = Convert.ToDouble(res[j, 5]);
                        for (int k = 0; k < 6; k++)
                        {
                            temporary = res[i, k];
                            res[i, k] = res[j, k];
                            res[j, k] = temporary;
                        }
                    }
                }
            }
            return res;
        }
        public string[,] SortTimeDuration(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            string[,] res = array;
            int max;
            string temporary;
            for (int i = 0; i < rows - 1; i++)
            {
                max = Convert.ToInt32(array[i, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[i, 3].Split(':')[1]);
                max = max - Convert.ToInt32(array[i, 2].Split(':')[0]) * 60 + Convert.ToInt32(array[i, 2].Split(':')[1]);
                for (int j = i + 1; j < rows; j++)
                {
                    if (max < Convert.ToInt32(array[j, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 3].Split(':')[1]) - Convert.ToInt32(array[j, 2].Split(':')[0]) * 60 - Convert.ToInt32(array[j, 2].Split(':')[1]))
                    {
                        max = Convert.ToInt32(array[j, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 3].Split(':')[1]) - Convert.ToInt32(array[j, 2].Split(':')[0]) * 60 - Convert.ToInt32(array[j, 2].Split(':')[1]);
                        for (int k = 0; k < 6; k++)
                        {
                            temporary = res[i, k];
                            res[i, k] = res[j, k];
                            res[j, k] = temporary;
                        }
                    }
                }
            }
            return res;
        }
        public string[,] SortTimeOpen(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            string[,] res = array;
            int min;
            string temporary;
            for (int i = 0; i < rows - 1; i++)
            {
                min = Convert.ToInt32(array[i, 2].Split(':')[0]) * 60 + Convert.ToInt32(array[i, 2].Split(':')[1]);
                for (int j = i + 1; j < rows; j++)
                {
                    if (min > Convert.ToInt32(array[j, 2].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 2].Split(':')[1]))
                    {
                        min = Convert.ToInt32(array[j, 2].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 2].Split(':')[1]);
                        for (int k = 0; k < 6; k++)
                        {
                            temporary = res[i, k];
                            res[i, k] = res[j, k];
                            res[j, k] = temporary;
                        }
                    }
                }
            }
            return res;
        }
        public string[,] SortTimeClose(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            string[,] res = array;
            int max;
            string temporary;
            for (int i = 0; i < rows - 1; i++)
            {
                max = Convert.ToInt32(array[i, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[i, 3].Split(':')[1]);
                for (int j = i + 1; j < rows; j++)
                {
                    if (max < Convert.ToInt32(array[j, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 3].Split(':')[1]))
                    {
                        max = Convert.ToInt32(array[j, 3].Split(':')[0]) * 60 + Convert.ToInt32(array[j, 3].Split(':')[1]);
                        for (int k = 0; k < 6; k++)
                        {
                            temporary = res[i, k];
                            res[i, k] = res[j, k];
                            res[j, k] = temporary;
                        }
                    }
                }
            }
            return res;
        }
        public string[,] SortName(string[,] array)
        {
            int rows = array.GetUpperBound(0) + 1;
            string[,] res = new string[rows,6];
            string[] names = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                names[i] = array[i, 1];
            }
            Array.Sort(names);
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (names[i] == array[j, 1])
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            res[i, k] = array[j, k];
                        }
                        break;
                    }
                }
            }
            return res;
        }
    }
}
