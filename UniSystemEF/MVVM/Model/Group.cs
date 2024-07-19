using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystemEF.MVVM.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string? Faculty { get; set; }
        public int AmountOfStudents { get; set; }
        public double GroupAverage { get; set; }

        public Group()
        {
            GroupName ??= "-";
        }

        public string PrintGroup()
        {
            string group = GroupName + ";" + Faculty + ";" + AmountOfStudents.ToString() + ";" + GroupAverage.ToString();
            return group;
        }
    }
}
