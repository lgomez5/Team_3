using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Team3.Models
{
    public class Grade
    {
        [PrimaryKey]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        
    }

}
