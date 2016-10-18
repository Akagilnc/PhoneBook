using Microsoft.VisualStudio.TestTools.UnitTesting;
using subtitle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subtitle.Tests
{
    [TestClass()]
    public class MakeSubtitleTests
    {
        private Key _key;
        private Hashtable _table;
        private readonly MakeSubtitle _makeSubtitle;
        public MakeSubtitleTests()
        {
            this._makeSubtitle = new MakeSubtitle();
        }

        [TestMethod()]
        public void Test()
        {
            FileToStringTest();
            ParserTimeTest();
            GetValueTest();
        }

        //[TestMethod()]
        public void FileToStringTest()
        {
            _table = _makeSubtitle.FileToString(@"C:\Users\lnc\Documents\Visual Studio 2015\Projects\PhoneBook\subtitle\test.srt");
            Assert.IsNotNull(_table);
        }

        //[TestMethod()]
        public void ParserTimeTest()
        {
            _key = new Key(_makeSubtitle.ParserTime("00:00:05,607"));
            Assert.IsNotNull(_key);
        }

        //[TestMethod()]
        public void GetValueTest()
        {
            string resultText = _makeSubtitle.GetValue(_table ,_key);
            
            if (resultText == null || resultText.Equals(""))
            {
                Assert.Fail();
            }
            
        }
    }
}