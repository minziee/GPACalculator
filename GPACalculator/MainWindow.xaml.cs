using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Course> courses;
        public MainWindow()
        {
            InitializeComponent();
            courses = new List<Course>();
            Course course1 = new Course(2, 2, "xd");
            courses.Add(course1);

            GPACalculation GPACalculator = new GPACalculation(courses);
            DataContext = GPACalculator.Calculate();
        }
        
        private bool IsEmpty(ComboBox Selection)
        {
            if(Selection.SelectedItem == null)
            {
                return true;
            }
            return false;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Make function that handles Course creation.
            //TODO: Make seperate helper function that converts grade selected to int value.
            courses = new List<Course>();

            if(!IsEmpty(Grade1) && !IsEmpty(Credits1))
            {
                Course course1 = new Course(int.Parse(Grade1.SelectedItem.ToString()), int.Parse(Credits1.SelectedItem.ToString()), Course1.Text);
                courses.Add(course1);
            }
            if (!IsEmpty(Grade2) && !IsEmpty(Credits2))
            {
                Course course2 = new Course(int.Parse(Grade2.SelectedItem.ToString()), int.Parse(Credits2.SelectedItem.ToString()), Course2.Text);
                courses.Add(course2);
            }
            if (!IsEmpty(Grade3) && !IsEmpty(Credits3))
            {
                Course course3 = new Course(int.Parse(Grade3.SelectedItem.ToString()), int.Parse(Credits3.SelectedItem.ToString()), Course3.Text);
                courses.Add(course3);
            }
            if (!IsEmpty(Grade4) && !IsEmpty(Credits4))
            {
                Course course4 = new Course(int.Parse(Grade4.SelectedItem.ToString()), int.Parse(Credits4.SelectedItem.ToString()), Course4.Text);
                courses.Add(course4);
            }
            if (!IsEmpty(Grade5) && !IsEmpty(Credits5))
            {
                Course course5 = new Course(int.Parse(Grade5.SelectedItem.ToString()), int.Parse(Credits5.SelectedItem.ToString()), Course5.Text);
                courses.Add(course5);
            }
            if (!IsEmpty(Grade6) && !IsEmpty(Credits5))
            {
                Course course6 = new Course(int.Parse(Grade6.SelectedItem.ToString()), int.Parse(Credits6.SelectedItem.ToString()), Course6.Text);
                courses.Add(course6);
            }

        }
    }
}
