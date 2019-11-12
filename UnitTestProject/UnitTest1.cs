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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string checkUsername = "unittestuser";

            User user = Task.Run(async()=>await App.Database.CheckUserAsync("unittestuser", "password")).Result;
            
            //Assert to check username are same
            Assert.AreEqual(checkUsername, user.Username);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string status = "pending";

            List<Assignment> list = Task.Run(async () => await App.Database.GetAssignmentList(status)).Result;

            //check to make sure pending assignment list has count more than zero
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string status = "completed";

            List<Assignment> list = Task.Run(async () => await App.Database.GetAssignmentList(status)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int gradeid = 6;

            List<Assignment> list = Task.Run(async () => await App.Database.GetGradeAssignmentList(gradeid)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreEqual(5, list[0].GradeId);

        }

        [TestMethod]
        public void TestMethod5()
        {
            string coursecode = "Course 4";

            List<Assignment> list = Task.Run(async () => await App.Database.GetCourseAssignmentList(coursecode)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreEqual(coursecode, list[0].CourseCode);

        }
    }
}
