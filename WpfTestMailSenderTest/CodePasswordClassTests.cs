using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfTestMailSender.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCodePassword_abc_bcd()
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
