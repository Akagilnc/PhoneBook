using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests
{
    [TestClass()]
    public class IndexTests
    {
        [TestMethod()]
        public void querybutton_ClickTest()
        {
            Index index = new Index();
            index.querybutton_Click(null, null);

            
        }
    }
}