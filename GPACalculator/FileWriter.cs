using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator
{
    class FileWriter
    {
        private List<Course> courses;
        private double GPA;

        public FileWriter(double GPA, List<Course> courses)
        {
            this.GPA = GPA;
            this.courses = courses;
        }

        public void SaveToFile()
        {
            SaveFileDialog save = new SaveFileDialog
            {
                FileName = "GPA Results.txt",
                Filter = "Text File | *.txt"
            };

            // Prompt user for save
            if (save.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                // Create formatted header for output and write to file
                string header = String.Format("{0,-50}{1,-20}{2,-20}",
                    "Title", "Credits", "Letter Grade");

                writer.WriteLine(header);

                // Iterate through each course and print details of course with same formatting as header.
                foreach(Course course in courses)
                {
                    writer.WriteLine("{0,-50}{1,-20}{2,-20}",
                        course.Title, course.Credits, course.LetterGrade);
                    
                }

                // Write the calculated GPA
                writer.WriteLine("GPA: " + GPA);

                writer.Dispose();
                writer.Close();
            }
        }


    }
}
