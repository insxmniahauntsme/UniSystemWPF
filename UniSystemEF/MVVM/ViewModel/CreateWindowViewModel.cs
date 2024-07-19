using System.Windows;
using System.Windows.Input;
using UniSystemEF.Commands;
using UniSystemEF.Data;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.MVVM.ViewModel
{
    class CreateWindowViewModel
    {
        readonly DataContext _context = DataContext.Instance; 
        readonly DataAccess _access = DataAccess.Instance; 

        public static object? _entity;

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
            string[] splittedText = createText.Split(';')
                ?? throw new ArgumentNullException(nameof(CreateText));

            try
            {
                if (_entity is Faculty faculty)
                {
                    if (splittedText.Length == 3) 
                    {   

                        faculty.FacultyName = splittedText[0] ?? "-";
                        faculty.Department = splittedText[1] ?? "-";
                        faculty.Note = splittedText[2] ?? "-";

                        _context.Add(faculty);
                        _access.Faculties.Add(faculty);
                             
                    }
                    else
                    {
                        MessageBox.Show("You need to enter all the cells of the row!");
                        throw new ArgumentOutOfRangeException(nameof(splittedText));
                    }

                }

                else if (_entity is Group group)
                {
                    if (splittedText.Length == 4)
                    {
                        group.GroupName = splittedText[0] ?? "-";
                        group.Faculty = splittedText[1] ?? "-";
                        group.AmountOfStudents = int.Parse(splittedText[2]);
                        group.GroupAverage = double.Parse(splittedText[3]);

                        _context.Add(group);
                        _access.Groups.Add(group);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter all the cells of the row!");
                        throw new ArgumentOutOfRangeException(nameof(splittedText));
                    }
                }

                else if (_entity is Student student)
                {
                    if (splittedText.Length == 4)
                    {
                        student.Surname = splittedText[0] ?? "-";
                        student.Name = splittedText[1] ?? "-";
                        student.GroupName = splittedText[2] ?? "-"  ;
                        student.AverageScore = double.Parse(splittedText[3]);

                        _context.Add(student);
                        _access.Students.Add(student);

                    }
                    else
                    {
                        MessageBox.Show("You need to enter all the cells of the row!");
                        throw new ArgumentOutOfRangeException(nameof(splittedText));
                    }

                }

                if (parameter is Window window)
                { 
                    window.DialogResult = true;
                    window.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect type of entered data!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid argument: {ex.Message}");
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
