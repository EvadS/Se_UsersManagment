using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserManagment.DAL.Abstract;

namespace UserManagment.WebTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IUserRepository> repo = new Mock<IUserRepository>();

          
        }
    }
}
