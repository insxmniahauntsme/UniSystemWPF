using System.Collections.ObjectModel;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.Data
{
    public class DataAccess
    {
        private static DataAccess? instance;
        public static DataAccess Instance
        {
            get
            {
                return instance ??= new DataAccess();
            }

            set
            {
                instance = value;
            }
        }

        private readonly DataContext _context;

        public ObservableCollection<Group> Groups { get; private set; }
        public ObservableCollection<Faculty> Faculties { get; private set; }
        public ObservableCollection<Student> Students { get; private set; }

        private DataAccess()
        {
            _context = DataContext.Instance;
            Groups = new ObservableCollection<Group>();
            Faculties = new ObservableCollection<Faculty>();
            Students = new ObservableCollection<Student>();

            GetGroups();
            GetFaculties();
            GetStudents();
        }

        public void GetGroups()
        {
            Groups.Clear();
            foreach (var group in _context.Groups.ToList())
            {
                Groups.Add(group);
            }
        }

        public void GetFaculties()
        {
            Faculties.Clear();
            foreach (var faculty in _context.Faculties.ToList())
            {
                Faculties.Add(faculty);
            }
        }

        public void GetStudents()
        {
            Students.Clear();
            foreach (var student in _context.Students.ToList())
            {
                Students.Add(student);
            }
        }
    }
}
