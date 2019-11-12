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
        public AssignmentList(string status)
        {
            InitializeComponent();
            GetAssignment(status);
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Assignment;
            if (item == null)
            {
                return;
            }
            else {
                await Navigation.PushModalAsync(new AssignmentDetails(item));
            }
            // Manually deselect item.
            AssignmentListView.SelectedItem = null;
        }


        private async void GetAssignment(string Status)
        {
            assignmentList = await App.Database.GetAssignmentList(Status);
            
            AssignmentListView.ItemsSource = assignmentList;
        }
    }
}