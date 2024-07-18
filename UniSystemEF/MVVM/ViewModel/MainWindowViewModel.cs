using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using UniSystemEF.Commands;
using UniSystemEF.Data;
using UniSystemEF.MVVM.Model;
using UniSystemEF.MVVM.View;

namespace UniSystemEF.MVVM.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly DataContext _context = DataContext.Instance;

        private readonly DataAccess _access = DataAccess.Instance;

        public ObservableCollection<Group> Groups => _access.Groups;
        public ObservableCollection<Faculty> Faculties => _access.Faculties;
        public ObservableCollection<Student> Students => _access.Students;

        private Visibility facultiesVisibility;
        private Visibility groupsVisibility;
        private Visibility studentsVisibility;

        public MainWindowViewModel()
        {
            FacultyCommand = new RelayCommand(o => ShowFaculties());
            GroupCommand = new RelayCommand(o => ShowGroups());
            StudentCommand = new RelayCommand(o => ShowStudents());
            DeleteRowCommand = new RelayCommand(DeleteRowButton);
            EditRowCommand = new RelayCommand(EditRowButton);
            CreateRowCommand = new RelayCommand(CreateRowButton);

            FacultiesVisibility = Visibility.Visible;
            GroupsVisibility = Visibility.Collapsed;
            StudentsVisibility = Visibility.Collapsed;
        }

        private string _gridName = "Факультети";

        public string GridName
        {
            get { return _gridName; }
            set
            {
                _gridName = value;
            }
        }

        public ICommand FacultyCommand { get; }
        public ICommand GroupCommand { get; }
        public ICommand StudentCommand { get; }
        public ICommand DeleteRowCommand { get; }
        public ICommand EditRowCommand { get; }
        public ICommand CreateRowCommand {  get; }

        public Visibility FacultiesVisibility
        {
            get { return facultiesVisibility; }
            set { facultiesVisibility = value; OnPropertyChanged(nameof(FacultiesVisibility)); }
        }

        public Visibility GroupsVisibility
        {
            get { return groupsVisibility; }
            set { groupsVisibility = value; OnPropertyChanged(nameof(GroupsVisibility)); }
        }

        public Visibility StudentsVisibility
        {
            get { return studentsVisibility; }
            set { studentsVisibility = value; OnPropertyChanged(nameof(StudentsVisibility)); }
        }

        private void ShowFaculties()
        {
            GridName = "Факультети";
            OnPropertyChanged(nameof(GridName));
            FacultiesVisibility = Visibility.Visible;
            GroupsVisibility = Visibility.Collapsed;
            StudentsVisibility = Visibility.Collapsed;
        }

        private void ShowGroups()
        {
            GridName = "Групи";
            OnPropertyChanged(nameof(GridName));
            FacultiesVisibility = Visibility.Collapsed;
            GroupsVisibility = Visibility.Visible;
            StudentsVisibility = Visibility.Collapsed;
        }

        private void ShowStudents()
        {
            GridName = "Студенти";
            OnPropertyChanged(nameof(GridName));
            FacultiesVisibility = Visibility.Collapsed;
            GroupsVisibility = Visibility.Collapsed;
            StudentsVisibility = Visibility.Visible;
        }

        public void DeleteRowButton(object? parameter)
        {

            if (parameter is Student student)
            {
                _access.Students.Remove(student);
                _context.Students.Remove(student);
                OnPropertyChanged(nameof(Students));
            }
            else if (parameter is Group group)
            {
                _access.Groups.Remove(group);
                _context.Groups.Remove(group);
                OnPropertyChanged(nameof(Groups));
            }
            else if (parameter is Faculty faculty)
            {
                _access.Faculties.Remove(faculty);
                _context.Faculties.Remove(faculty);
                OnPropertyChanged(nameof(Faculties));
            }

            _context.SaveChanges();
        }

        public static void LoadData()
        {
            var dataAccess = DataAccess.Instance;

            dataAccess.GetStudents();
            dataAccess.GetGroups();
            dataAccess.GetFaculties();        

        }

        private void EditRowButton(object? parameter)
        {
            
            if (_context.Faculties.Contains(parameter as Faculty))
            {
                Faculty faculty = (Faculty) parameter;
                OpenEditWindow(faculty);

            }
            else if (_context.Students.Contains(parameter as Student))
            {
                Student student = (Student) parameter;
                OpenEditWindow(student);
            }
            else if (_context.Groups.Contains(parameter as Group))
            {
                Group group = (Group) parameter;
                OpenEditWindow(group);
            }
            
        }

        private void OpenEditWindow(object? entity)
        {
            EditWindow editWindow = new EditWindow();
            EditWindow._entity = entity;

            if (editWindow.DataContext is EditWindowViewModel editWindowViewModel)
            {
                switch (entity)
                {
                    case Faculty faculty:
                        editWindowViewModel.EditText = faculty.PrintFaculty();
                        break;
                    case Group group:
                        editWindowViewModel.EditText = group.PrintGroup();
                        break;
                    case Student student:
                        editWindowViewModel.EditText = student.PrintStudent();
                        break;
                }

                
            }
            editWindow.ShowDialog();
        }

        public void CreateRowButton(object? parameter)
        {
            if(FacultiesVisibility == Visibility.Visible)
            {
                Faculty faculty = new Faculty();
                CreateWindowViewModel._entity = faculty;
                CreateWindow createWindow = new CreateWindow();
                createWindow.ShowDialog();
            }

            if (GroupsVisibility == Visibility.Visible)
            {
                Group group = new Group();
                CreateWindowViewModel._entity = group;
                CreateWindow createWindow = new CreateWindow();
                createWindow.ShowDialog();
            }

            if (StudentsVisibility == Visibility.Visible)
            {
                Student student = new Student();
                CreateWindowViewModel._entity = student;
                CreateWindow createWindow = new CreateWindow();
                createWindow.ShowDialog();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }



}
