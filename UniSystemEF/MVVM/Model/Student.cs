using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystemEF.MVVM.Model
{
    public class Student
    {
        public DateTime RegistrationDate { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string GroupName { get; set; }
        public double AverageScore { get; set; }
        public Student()
        {
            if (GroupName == null)
            {
                GroupName = "-";
            }
        }

        public string PrintStudent()
        {
            string student = Surname + ";" + Name + ";" + GroupName + ";" + AverageScore.ToString();
            return student;
        }
    }

}
