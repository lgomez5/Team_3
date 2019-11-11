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
        public AssignmentList ()
		{
			InitializeComponent();
            
            GetAssignment();
        }

        private async void GetAssignment()
        {
            assignmentList = await App.Database.GetAssignmentList();
            AssignmentListView.ItemsSource = assignmentList;
        }
    }
}