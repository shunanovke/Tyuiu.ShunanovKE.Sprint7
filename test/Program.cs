using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyuiu.ShunanovKE.Sprint7.Project.V1.Lib;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService(); 
            string[,] array = {  { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };

            string[,] res = ds.SortRate(array);
            int rows = res.GetUpperBound(0) + 1;
            int cols = res.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Console.Write(res[i, j] + ' ');
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
