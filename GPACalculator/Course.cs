using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GPACalculator
{
    public class Course
    {
        public int Credits { get; private set; }
        public string LetterGrade { get; private set; }
        public double NumberGrade { get; private set; }
        public string Title { get; private set; }
        public double WeightedGrade { get; private set; }

        public Course()
        {}
        public Course(ComboBox LetterGrade, ComboBox Credits, string Title)
        {
            this.NumberGrade = ConvertToDouble(LetterGrade);
            this.LetterGrade = LetterGrade.Text.ToString();
            this.Credits = ConvertToInteger(Credits);
            this.Title = Title;
            WeightedGrade = this.NumberGrade * this.Credits;
        }

        private int ConvertToInteger(ComboBox Credits)
        {
            return int.Parse(Credits.Text);
        }

        private double ConvertToDouble(ComboBox Grade)
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


    }
}
