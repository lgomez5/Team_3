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
	public partial class CoursesList : ContentPage
	{
        List<Course> coursesList = new List<Course>();

        public CoursesList ()
		{
			InitializeComponent ();
            GetCourses();
		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Course;
            if (item == null)
            {
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new CourseDetail(item));
            }
            // Manually deselect item.
            CoursesListView.SelectedItem = null;
        }

        private async void GetCourses()
        {
            coursesList = await App.Database.GetCoursesList();

            CoursesListView.ItemsSource = coursesList;
        }
    }
}