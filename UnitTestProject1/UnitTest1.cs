using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestMethod1()
        {
            PetShopDbContext db = new PetShopDbContext();
            var item = db.Items.Find("EST-28");
            Console.WriteLine($"Id: {item.ItemId}");
        }
    }
}
