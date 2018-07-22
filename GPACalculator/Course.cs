using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator
{
    public class Course
    {
        public int Grade { get; private set; }
        public int Credits { get; private set; }
        private string CourseTitle { get; set; }
        public int WeightedGrade;

        public Course()
        {}
        public Course(int Grade, int Credits, string CourseTitle)
        {
            this.Grade = Grade;
            this.Credits = Credits;
            this.CourseTitle = CourseTitle;
            WeightedGrade = this.Grade * this.Credits;
        }


    }
}
