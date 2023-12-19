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
    }
}
