using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator
{
    public class GPACalculation
    {
        private List<Course> courses;
        private double GPA;
        private int TotalCredits;
        private double TotalWeightedGradePoints;

        public GPACalculation(List<Course> courses)
        {
            this.courses = courses;
            TotalCredits = 0;
            TotalWeightedGradePoints = 0;
        }

        public double Calculate()
        {         
            foreach(Course course in courses)
            {
                // Add up credits and weighted grade points 
                // from courses to get totals
                TotalCredits = TotalCredits + course.Credits;
                TotalWeightedGradePoints = 
                    TotalWeightedGradePoints + course.WeightedGrade;
            }

            GPA = (TotalWeightedGradePoints / TotalCredits);

            return Math.Round(GPA,2);
        }
    }
}
