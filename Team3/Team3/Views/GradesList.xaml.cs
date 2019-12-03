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
	public partial class GradesList : ContentPage
	{
        List<Grade> gradesList = new List<Grade>();
        public GradesList ()
		{
			InitializeComponent ();
            GetGrades();
		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Grade;
            if (item == null)
            {
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new GradeDetails(item));
            }
            // Manually deselect item.
            GradesListView.SelectedItem = null;
        }


        private async void GetGrades()
        {
            gradesList = await App.Database.GetGradesList();

            GradesListView.ItemsSource = gradesList;
        }
    }
}