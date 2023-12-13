using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.ShunanovKE.Sprint7.Project.V1.Lib;

namespace Tyuiu.ShunanovKE.Sprint7.Project.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataService ds = new DataService();
            string path = @"C:\DataSprint7\InPutTestFileProjectV1.csv";
            string[,] res = ds.GetMatrix(path);
            string[,] wait = { { "1", "CarExpress", "9:00", "18:00", "83452393500", "4,9" },
                               { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" }};
            CollectionAssert.AreEqual(wait, res);
        }
    }
}
