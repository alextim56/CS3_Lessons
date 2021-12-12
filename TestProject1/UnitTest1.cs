using NUnit.Framework;
using WpfTestMailSender;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
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