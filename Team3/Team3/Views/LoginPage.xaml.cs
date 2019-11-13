using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Data;
using Team3.Models;
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
           
           await App.Database.SaveUserAsync(new Models.User {
                Id=123,
                Username="user2",
                FirstName="team",
                LastName="three",
                Password="password",
                UserType="teacher",
                DateCreated=DateTime.Now
           });
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {

            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
            try
            {
                User obj = Task.Run(async () => await App.Database.CheckUserAsync(username, password)).Result;

                if (!obj.Equals(null)) {
                    if (obj.UserType.Equals("teacher"))
                    {
                        await Navigation.PushModalAsync(new TeacherHome());
                    }
                    else if (obj.UserType.Equals("guardian"))
                    {
                        await Navigation.PushModalAsync(new GuardianHome()); // avoid back button 
                    }
                }
            }
            catch (AggregateException ex) {
                await DisplayAlert("Wrong username/password", "Please enter correct credentials", "Try Again");
            }
        }
    }
}