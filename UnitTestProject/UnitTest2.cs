using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team3;
using Team3.Data;
using Team3.Models;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            User user = new User
            {
                Username = "user-unit",
                Password = "unit-password",
                UserType = "student"
            };

            try
            {
                //check to make sure user insertion in db
                Task.Run(async () => await App.Database.SaveUserAsync(user));
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
