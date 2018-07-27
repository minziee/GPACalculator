using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator
{
    public class GPAMainMenu
    {
        public static List<Course> courses;

        static void Main()
        {
            Course Course1 = new Course();
            courses.Add(Course1);


            GPACalculator GPACalculator = new GPACalculator(courses);
            GPACalculator.Calculate();

            
        }
    }
}
