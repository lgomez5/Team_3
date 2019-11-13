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
	public partial class AddUser : ContentPage
	{
		public AddUser ()
		{
			InitializeComponent ();
		}

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            try { 
                string Gradeid = SelectGrade.SelectedItem.ToString();
                int gradeId = Convert.ToInt32(Gradeid.Substring(Gradeid.Length - 1));

                User user = new User
                {
                    Username = Username.Text,
                    Password = Password.Text,
                    GradeId = gradeId,
                    CourseCode = SelectCourse.SelectedItem.ToString(),
                    UserType = SelectUsersType.SelectedItem.ToString().ToLower(),
                    DateCreated = DateTime.Now
                };

                await App.Database.SaveUserAsync(user);
                await DisplayAlert("User Account", "New user created", "Ok");
                SetFieldsEmpty();
            }
            catch(NullReferenceException ex){
                await DisplayAlert("User Account Error", "Please fill all the fields", "Try Again");
            }
        }
        public void SetFieldsEmpty() {
            Username.Text = "";
            Password.Text = "";
            SelectCourse.SelectedItem = null;
            SelectUsersType.SelectedItem = null;
            SelectGrade.SelectedItem = null;
        }
    }
}