using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team3.Models
{
    public class Course
    {
        [PrimaryKey]
        public string CourseCode { get; set; }
        public int GradeId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
    }
}