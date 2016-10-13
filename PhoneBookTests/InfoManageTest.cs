using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook;

namespace PhoneBookTests
{
    [TestClass()]
    public class InfoManageTest
    {
        private InfoManage infoManage;

        public InfoManageTest()
        {
            infoManage = new InfoManage();
        }

        [TestMethod()]
        public void GetInfoTest()
        {
            String currectResult = "Name:Deron    PhoneNum:18829839020\n";
            var result = infoManage.GetInfo("Deron");
           
            Assert.AreEqual(result, currectResult);
            
         
        }

        [TestMethod()]
        public void InsertTest()
        {
            int currectResult = 1;

            int result = infoManage.Insert();

            Assert.AreEqual(result, currectResult);

        }
    }
}
