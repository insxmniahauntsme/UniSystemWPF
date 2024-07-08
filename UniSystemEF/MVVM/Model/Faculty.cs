namespace UniSystemEF.MVVM.Model
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Department { get; set; }
        public string Note { get; set; }

        public Faculty()
        {
            if (FacultyName == null)
            {
                FacultyName = "-";
            }

            if (Department == null)
            {
                Department = "-";
            }

            if (Note == null)
            {
                Note = "-"; 
            }

        }

        public string PrintFaculty()
        {
            string faculty = FacultyId.ToString() + ";" + FacultyName + ";" + Department + ";" + Note;
            return faculty;
        }
    }
}
