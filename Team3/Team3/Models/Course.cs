using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team3.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
    }
}