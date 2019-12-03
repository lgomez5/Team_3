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
	public partial class CourseDetail : ContentPage
	{
		public CourseDetail ()
		{
			InitializeComponent ();
		}

        public CourseDetail(Course course)
        {
            InitializeComponent();

            BindingContext = course;
        }
    }
}