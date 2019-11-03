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

            await App.Database.SaveUserAsync(new Models.User {
                Id=123,
                Username="user",
                FirstName="team",
                LastName="three",
                Password="password",
                UserType="teacher",
                DateCreated=DateTime.Now
            });
        }

        public async void OnButtonClicked(object sender, EventArgs e)
        {
            //(sender as Button).Text = "Click me again!";
            String username = usernameEntry.Text;
            String password = passwordEntry.Text;
            bool obj = App.Database.CheckUserAsync(username, password);

            if (obj) {
                // get loggedin user role
                string userRole = App.Database.GetRole(username);
                if (userRole == "teacher")
                {
                    await Navigation.PushModalAsync(new TeacherHome()); // avoid back button 
                   // Navigation.PushAsync(new TeacherHome());
                }else {
                    await Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}