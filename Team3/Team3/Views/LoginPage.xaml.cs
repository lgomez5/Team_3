using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Team3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            int i=Task.Run(async () => await App.Database.SaveUserAsync(new Models.User {
                Id=123,
                Username="user",
                FirstName="team",
                LastName="three",
                Password="password",
                UserType="teacher",
                DateCreated=DateTime.Now
            })).Result;

            int i1 = Task.Run(async () => await App.Database.SaveUserAsync(new Models.User
            {
                Id = 123,
                Username = "user1",
                FirstName = "piyush",
                LastName = "sehli",
                Password = "password",
                UserType = "teacher",
                DateCreated = DateTime.Now
            })).Result;

            int i2 = Task.Run(async () => await App.Database.SaveUserAsync(new Models.User
            {
                Id = 123,
                Username = "user2",
                FirstName = "parth",
                LastName = "jani",
                Password = "password",
                UserType = "guardian",
                DateCreated = DateTime.Now
            })).Result;

            //await DisplayAlert("Result", (i+i1+i2).ToString(), "OK");

        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            //(sender as Button).Text = "Click me again!";
            String username = usernameEntry.Text;
            String password = passwordEntry.Text;

            bool obj = Task.Run(async () => await App.Database.CheckUserAsync(username, password)).Result;
            if (obj) {
                // get loggedin user role
                string userRole = Task.Run(async () => await App.Database.GetRole(username)).Result;
                if (userRole == "teacher")
                {
                    await Navigation.PushModalAsync(new TeacherHome()); // avoid back button 
                   // Navigation.PushAsync(new TeacherHome());
                }
                else if (userRole == "guardian")
                {
                    await Navigation.PushModalAsync(new GuardianHome()); // avoid back button 
                }
            }
            else
            {
                await DisplayAlert("Wrong username/password", "Please enter correct credentials", "OK");
            }
        }
    }
}