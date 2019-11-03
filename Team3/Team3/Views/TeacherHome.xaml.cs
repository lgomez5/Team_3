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
    public partial class TeacherHome : ContentPage
    {
        public TeacherHome()
        {
            InitializeComponent();
        }
        public async void LogoutButton(object sender, EventArgs e) {
            // remove if any type of localstorage is being used
            await Navigation.PushModalAsync(new LoginPage()); // avoid back button 
        }
        public async void NavigatePostHomework(object sender, EventArgs e) {
            await DisplayAlert("Alert", "Please add link to next page", "OK");
            // Navigation.PushAsync(new TeacherHome()); use PushAsync to have a back navigation button
        }
        public async void NavigateViewHomework(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Please add link to next page", "OK");
        }
        public async void NavigateViewGrades(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Please add link to next page", "OK");
        }
        public async void NavigateViewCourses(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Please add link to next page", "OK");
        }
    }
}