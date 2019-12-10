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
    public partial class GuardianHome : ContentPage
    {
        string status;
        public GuardianHome()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

        }
        public async void LogoutBtnClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        public async void PendingAssignment_BtnClick(object sender, EventArgs e)
        {
            status = "pending";
            await Navigation.PushModalAsync(new AssignmentList(status));
        }
        public async void CompletedAssignment_BtnClick(object sender, EventArgs e)
        {
            status = "completed";
            await Navigation.PushModalAsync(new AssignmentList(status));
        }
    }
}