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
    public class Unit_Test_Release2
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            List<Course> list = Task.Run(async () => await App.Database.GetCoursesList()).Result;

            //check to make sure pending assignment list has count more than zero
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {

            List<Grade> list = Task.Run(async () => await App.Database.GetGradesList()).Result;

            //check to make sure pending assignment list has count more than zero
            Assert.AreNotEqual(0, list.Count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int gradeid = 6;

            List<Course> list = Task.Run(async () => await App.Database.GetCoursesForGrade(gradeid)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreEqual(6, list[0].GradeId);

        }

        [TestMethod]
        public void TestMethod4()
        {
            int gradeid = 9;

            List<Assignment> list = Task.Run(async () => await App.Database.GetGradeAssignmentList(gradeid)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreEqual(5, list[0].GradeId);

        }

        [TestMethod]
        public void TestMethod5()
        {
            string coursecode = "Course 5";

            List<Assignment> list = Task.Run(async () => await App.Database.GetCourseAssignmentList(coursecode)).Result;

            //check to make sure completed assignment list has count more than zero
            Assert.AreEqual(coursecode, list[0].CourseCode);

        }
    }
}
