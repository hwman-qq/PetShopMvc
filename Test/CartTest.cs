using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

using PetShop.BLL;
using PetShop.Model;

namespace Test
{
    
    
    /// <summary>
    ///这是 CartTest 的测试类，旨在
    ///包含所有 CartTest 单元测试
    ///</summary>
    [TestClass()]
    public class CartTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
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

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Total 的测试
        ///</summary>
        [TestMethod()]
        public void TotalTest()
        {
            Cart target = new Cart(); // TODO: 初始化为适当的值
            Decimal expected = new Decimal(); // TODO: 初始化为适当的值
            Decimal actual;
            target.Total = expected;
            actual = target.Total;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        //自己手工编写的测试，更灵活，可以综合测试类的多个方法
        [TestMethod()]
        public void ProductBLLTest()
        {
            Product productBLL = new Product();
            IList products = productBLL.GetProductsByCategory("BIRDS");
            foreach (ProductInfo x in products)
            {
                Console.WriteLine("ID: {0}, Name: {1}", x.Id, x.Name);
            }
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod()]
        public void AccountBLLTest()
        {
            Account accountBLL = new Account();
            AccountInfo a1 = accountBLL.SignIn("ACID", "ACID"); //系统内置的账户
            Assert.IsNotNull(a1);
            AccountInfo a2 = accountBLL.SignIn("DotNet", "DotNet");
            Assert.IsNotNull(a2);
            Assert.AreEqual<string>(a1.UserId, "ACID");
            AccountInfo a3 = accountBLL.SignIn("abc", "hello");//不存在的账户, 结果应该为Null
            Assert.IsNull(a3);
        }

    }
}
