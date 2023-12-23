using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.ShunanovKE.Sprint7.Project.V1.Lib;

namespace Tyuiu.ShunanovKE.Sprint7.Project.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        DataService ds = new DataService();
        [TestMethod]
        public void GetMatrixValid()
        {
            string path = @"C:\DataSprint7\InPutTestFileProjectV1.csv";
            string[,] res = ds.GetMatrix(path);
            string[,] wait = { { "1", "CarExpress", "9:00", "18:00", "83452393500", "4,9" },
                               { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" }};
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortNumValid()
        {
            string[,] array = { { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" } };
            string[,] res = ds.SortNum(array);
            string[,] wait = {  { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortRatevalid()
        {
            string[,] array = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };
            string[,] res = ds.SortRate(array);
            string[,] wait = { { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                               { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                               { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" } };
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortTimeDurationValid()
        {
            string[,] array = { { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" } };
            string[,] res = ds.SortTimeDuration(array);
            string[,] wait = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortTimeOpenValid()
        {
            string[,] array = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };
            string[,] res = ds.SortTimeOpen(array);
            string[,] wait = { { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" } };
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortTimeCloseValid()
        {
            string[,] array = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" } };
            string[,] res = ds.SortTimeClose(array);
            string[,] wait = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" } };
            CollectionAssert.AreEqual(wait, res);
        }


        [TestMethod]
        public void SortNameValid()
        {
            string[,] array = { { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" } };
            //string[,] res = ds.SortName(array);
            string[,] wait = { { "2", "AutoLeague", "10:00", "18:00", "83452500007", "4,2" },
                                { "3", "CarCarCar", "8:10", "16:00", "83452337690", "3,7" },
                                { "1", "CarExpress", "9:00", "20:00", "83452393500", "3,5" } };
            //CollectionAssert.AreEqual(wait, res);
        }
    }
}
