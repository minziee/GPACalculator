using Microsoft.Win32;
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
            
            // Group credits, credits, and titles together as unprocessed/raw courses
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

            // for each raw course in list  
            foreach (RawCourse course in RawCourseList)
            {
                // If grades and credits aren't empty the course is valid
                if (!IsEmpty(course.Grade) && !IsEmpty(course.Credits))
                {
                    // Add to list of valid courses after converting grades and credits             
                    ValidCourseList.Add(new Course(course.Grade,
                        course.Credits, course.title));
                }
            }

            // If list does not have a least 1 valid course
            if (ValidCourseList.Count < 1)
            {
                // Show message box notifying user there were no valid courses
                MessageBox.Show("No valid courses were added.", "Error");
            }
            else
            {
                // Calculate GPA from list of valid courses
                GPACalculation GPACalculator = new GPACalculation(ValidCourseList);
                double GPA = GPACalculator.Calculate();
                DataContext = GPACalculator.Calculate();

                // Show message box notifying user and ask if they
                // would like to save conents to file.
                var WantToSave = MessageBox.Show("Calculation completed." +
                    "\nWould you like to save to file?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(WantToSave == MessageBoxResult.Yes)
                {
                    FileWriter fileWriter = new FileWriter(GPA, ValidCourseList);
                    fileWriter.SaveToFile();
                }           

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
