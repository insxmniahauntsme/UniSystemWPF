using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using UniSystemEF.Commands;
using UniSystemEF.Data;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.MVVM.ViewModel
{
    class CreateWindowViewModel
    {
        DataContext _context = DataContext.Instance; 
        DataAccess _access = DataAccess.Instance; 

        public static object _entity;

        private string? createText = "";
        public string? CreateText
        {
            get { return createText; }
            set
            {
                createText = value;
            }
        }
        public ICommand CreateCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CreateWindowViewModel() 
        {
            CreateCommand = new RelayCommand(CreateButton);
            CancelCommand = new RelayCommand(CancelButton);
        }

        public void CreateButton(object? parameter)
        {
            string[] splittedText = createText.Split(';') ?? throw new ArgumentNullException(nameof(CreateText));

            if (_entity is Faculty faculty) 
            {   

                faculty.FacultyName = splittedText[0] ?? "-";
                faculty.Department = splittedText[1] ?? "-";
                faculty.Note = splittedText[2] ?? "-";

                _context.Add(faculty);
                _access.Faculties.Add(faculty);
                             
            }

            else if (_entity is Group group)
            {
                group.GroupName = splittedText[0] ?? "-";
                group.Faculty = splittedText[1] ?? "-";
                group.AmountOfStudents = int.Parse(splittedText[2]);
                group.GroupAverage = double.Parse(splittedText[3]);

                _context.Add(group);
                _access.Groups.Add(group);
            }

            else if (_entity is Student student)
            {
                student.Surname = splittedText[0] ?? "-";
                student.Name = splittedText[1] ?? "-";
                student.GroupName = splittedText[2] ?? "-"  ;
                student.AverageScore = double.Parse(splittedText[3]);

                _context.Add(student);
                _access.Students.Add(student);

            }

            if (parameter is Window window)
            { 
                window.DialogResult = true;
                window.Close();
            }

            _context.SaveChanges();
        }
        
        public void CancelButton(object? parameter) 
        {
            if(parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

    }
}
