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
	public partial class CreateAssignment : ContentPage
	{
		public CreateAssignment ()
		{
			InitializeComponent ();
		}

        public async void OnButtonClicked(object sender, EventArgs e) {
            try { 
                string Gradeid = SelectGrade.SelectedItem.ToString();
                int gradeId = Convert.ToInt32(Gradeid.Substring(Gradeid.Length-1));

                Assignment assignment = new Assignment
                {
                    Title=AssignmentTitle.Text,
                    Description = DescriptionEntry.Text,
                    GradeId=gradeId,
                    CourseCode=SelectCourse.SelectedItem.ToString(),
                    SubmissionDate= SubmissionDateTime.Text,
                    CreationDate = DateTime.Now,
                    Status = "pending"
                };

                await App.Database.SaveAssignmentAsync(assignment);
                await DisplayAlert("Assignment", "New assignment posted", "Ok");
                SetFieldsEmpty();
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Post Assignment Error", "Please fill all the fields", "Try Again");
            }
        }
        public void SetFieldsEmpty()
        {
            AssignmentTitle.Text = "";
            DescriptionEntry.Text = "";
            SubmissionDateTime.Text = "";
            SelectCourse.SelectedItem = null;
            SelectGrade.SelectedItem = null;
        }

    }
}