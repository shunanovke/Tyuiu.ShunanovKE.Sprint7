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

        public int TimeOfWork(string open, string close)
        {
            int minsOpen = Convert.ToInt32(open.Split(':')[0]) * 60 + Convert.ToInt32(open.Split(':')[1]);
            int minsClose = Convert.ToInt32(close.Split(':')[0]) * 60 + Convert.ToInt32(close.Split(':')[1]);
            return minsClose - minsOpen;
        }
    }
}
