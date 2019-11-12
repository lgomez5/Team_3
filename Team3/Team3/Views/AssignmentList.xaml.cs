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
        string Status;
        List<Assignment> assignmentList = new List<Assignment>();
        public AssignmentList (string status)
		{
			InitializeComponent();
            Status = status;
            GetAssignment();
        }

        private async void GetAssignment()
        {
            assignmentList = await App.Database.GetAssignmentList();
            if (assignmentList != null)
            {
                if (Status == "pending")
                {
                    assignmentList.Remove(assignmentList.Single(s => s.Status == "completed"));
                }
                else if (Status == "completed")
                {
                    assignmentList.Remove(assignmentList.Single(s => s.Status == "pending"));
                }
            }
            AssignmentListView.ItemsSource = assignmentList;
        }
    }
}