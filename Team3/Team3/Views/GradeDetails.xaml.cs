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
	public partial class GradeDetails : ContentPage
	{
        List<Course> courses = new List<Course>();
		public GradeDetails ()
		{
			InitializeComponent ();
		}

        public GradeDetails(Grade grade)
        {
            InitializeComponent();

            GetCoursesOfGrade(grade.GradeId);

        }

        public async void GetCoursesOfGrade(int gradeid) {
            courses = await App.Database.GetCoursesForGrade(gradeid);
            CoursesListView.ItemsSource = courses;
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
    }
}