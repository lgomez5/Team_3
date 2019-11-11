using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Team3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssignmentList : ContentPage
	{
        List<Assignment> assignmentList = new List<Assignment>();
        public AssignmentList ()
		{
			InitializeComponent();
            
            Assignment assignment = new Assignment {
            Id = 1,
            GradeId = 2,
            CourseCode = "Comp122",
            CreationDate = DateTime.Now,
            SubmissionDate = DateTime.Now.ToShortDateString(),
            Title = "Assignment 1",
            Description = "Assignment 1 description",
            Teacher = "Teacher 1",
            Status = "pending"
            };

            assignmentList.Add(assignment);
            //assignmentList = Task.Run(async () => await App.Database.GetAssignmentList()).Result;
        }
	}
}