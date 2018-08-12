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
        public struct RawCourse
        {
            public ComboBox Grade, Credits;
            public string title;
            public RawCourse(ComboBox Grade, ComboBox Credits, string title)
            {
                this.Grade = Grade;
                this.Credits = Credits;
                this.title = title;
            }
        };

        public MainWindow()
        {            
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Group credits, credits, and titles together as valid courses(Assumed valid initially)
            RawCourse RawCourse1 = new RawCourse(Grade1, Credits1, Course1.Text);
            RawCourse RawCourse2 = new RawCourse(Grade2, Credits2, Course2.Text);
            RawCourse RawCourse3 = new RawCourse(Grade3, Credits3, Course3.Text);
            RawCourse RawCourse4 = new RawCourse(Grade4, Credits4, Course4.Text);
            RawCourse RawCourse5 = new RawCourse(Grade5, Credits5, Course5.Text);
            RawCourse RawCourse6 = new RawCourse(Grade6, Credits6, Course6.Text);

            // Make list of raw courses
            var RawCourseList = new List<RawCourse>
            { RawCourse1,RawCourse2, RawCourse3,
              RawCourse4, RawCourse5, RawCourse6};

            //Initialize list of valid courses
            var ValidCourseList = new List<Course>();

            // for each valid course in list  
            foreach (RawCourse course in RawCourseList)
            {
                // If grades and credits aren't empty the course is valid
                if (!IsEmpty(course.Grade) && !IsEmpty(course.Credits))
                {
                    // Add to course after converting grades and credits
                    // Add to list of valid courses
                    ValidCourseList.Add(new Course(ConvertToGrade(course.Grade),
                        ConvertToCredits(course.Credits), course.title));
                }
            }


            // If list does not have a least 1 course
            if (ValidCourseList.Count < 1)
            {
                // Show message box notifying user there were no valid courses
                MessageBox.Show("No valid courses were added.");
            }
            else
            {
                // Calculate GPA from list of valid courses
                GPACalculation GPACalculator = new GPACalculation(ValidCourseList);
                DataContext = GPACalculator.Calculate();

                // Show message box notifying user and ask if they
                // TODO: would like to save conents to file.
                MessageBox.Show("Calculation completed.");

            }
        }

        private int ConvertToCredits(ComboBox Credits)
        {
            return int.Parse(Credits.Text);
        }

        private double ConvertToGrade(ComboBox Grade)
        {

            // convert string representation of grade to number equivalent
            switch (Grade.Text.ToString())
            {
                case "A":
                    return 4.0;
                case "A-":
                    return 3.7;
                case "B+":
                    return 3.3;
                case "B":
                    return 3.0;
                case "B-":
                    return 2.7;
                case "C+":
                    return 2.3;
                case "C":
                    return 2.0;
                case "C-":
                    return 1.7;
                case "D+":
                    return 1.3;
                case "D":
                    return 1.0;
                case "F":
                    return 0.0;
                default:
                    return 0.0;
            }
        }

        private bool IsEmpty(ComboBox Selection)
        {
            if (Selection.SelectedItem == null)
            {
                return true;
            }
            return false;
        }

        private void Grade1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
