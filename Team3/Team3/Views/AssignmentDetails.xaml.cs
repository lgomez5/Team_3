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
	public partial class AssignmentDetails : ContentPage
	{
		public AssignmentDetails ()
		{
			InitializeComponent ();
		}

        public int id;
        public AssignmentDetails(Assignment assignment)
        {
            InitializeComponent();
            id = assignment.Id;
            BindingContext = assignment;
        }

        public async void OnStatusButtonClicked(object sender, EventArgs e)
        {
            try
            {
                string status = ChangeStatus.SelectedItem.ToString();
                if (!status.Equals(""))
                {
                    await App.Database.ChangeAssignmentStatus(id, status);

                    await DisplayAlert("Assignment Status", "Status changed!", "Ok");
                }
                else {
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException ex)
            {
                await DisplayAlert("Status change Error", "Please select the status", "Try Again");
            }
        }
    }
}