using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfTestMailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender.Tests
{
    [TestClass()]
    public class CodePasswordClassTests
    {
        [TestMethod()]
        public void GetPasswordTest_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = CodePasswordClass.GetCodePassword(strIn);
            // assert
            
        }
    }
}