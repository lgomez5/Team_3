﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team3.Models
{
    public class Assignment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int GradeId { get; set; }
        public string CourseCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}