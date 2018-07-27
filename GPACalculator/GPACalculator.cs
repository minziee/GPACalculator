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
        private float GPA;
        private int TotalCredits;
        private int TotalGradePoints;

        public GPACalculation(List<Course> courses)
        { this.courses = courses;}

        public float Calculate()
        {         
            foreach(Course course in courses)
            {
                TotalCredits = TotalCredits + course.Credits;
                TotalGradePoints = TotalGradePoints + course.Grade;
            }

            GPA = ((TotalGradePoints * TotalCredits) / TotalCredits);

            return GPA;
        }
    }
}
