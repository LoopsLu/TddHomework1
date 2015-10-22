using System;
using System.Collections.Generic;
using System.Data;
using ExpectedObjects;
using NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MsTestIntroduction
{
    [TestClass]
    public class Test
    {
        public Test()
        {
            //
            // TODO:  在此加入建構函式的程式碼
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合
        ///的相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性

        //
        // 您可以使用下列其他屬性撰寫您的測試:
        //
        // 執行該類別中第一項測試前，使用 ClassInitialize 執行程式碼
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在類別中的所有測試執行後，使用 ClassCleanup 執行程式碼
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在執行每一項測試之後，使用 TestCleanup 執行程式碼
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion 其他測試屬性

        private List<Order> Orders = new List<Order>()
            {
                new Order() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Order() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Order() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Order() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Order() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Order() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Order() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Order() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Order() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Order() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Order() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };

        [TestMethod]
        public void Test_Order_Group_Sum_By_Cost()
        {
            var orderHelper = new OrderHelper();

            var expected = new[] { 6, 15, 24, 21 };

            int productCountLimit = 3;
            var actual = orderHelper.GetOrderSum(Orders, "Cost", productCountLimit);
            
            expected.ToExpectedObject().ShouldEqual(actual.ToArray());
        }

        [TestMethod]
        public void Test_Order_Group_Sum_By_Revenue()
        {
            var orderHelper = new OrderHelper();

            var expected = new[] { 50, 66, 60 };

            int productCountLimit = 4;
            var actual = orderHelper.GetOrderSum(Orders, "Revenue", productCountLimit);

            expected.ToExpectedObject().ShouldEqual(actual.ToArray());
        }

    }
    internal class Order
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
        public int? Empty { get; set; }
    }

    internal class OrderHelper
    {
        public OrderHelper()
        {
            
        }

        public int[] GetOrderSum(List<Order> orders, string columnName, int productCountLimit)
        {
            return null;
        }
    }

    internal interface IOrderHelper
    {
        int[] GetOrderSum(List<Order> orders, string columnName, int productCountLimit);
    }
}


