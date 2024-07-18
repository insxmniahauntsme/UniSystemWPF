using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using UniSystemEF.Commands;
using UniSystemEF.Data;
using UniSystemEF.MVVM.Model;
using UniSystemEF.MVVM.View;

namespace UniSystemEF.MVVM.ViewModel
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        private string? _editText;

        public string? EditText
        {
            get { return _editText; }
            set
            {
                if (_editText != value)
                {
                    _editText = value;
                    OnPropertyChanged(nameof(EditText));
                }
            }
        }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; }

        public EditWindowViewModel()
        {
            CancelCommand = new RelayCommand(CancelButton);
            OkCommand = new RelayCommand(OkButton);
        }
        private void OkButton(object parameter)
        {
            DataContext context = DataContext.Instance;
            DataAccess access = DataAccess.Instance;

            string[] editedText = EditText.Split(';');

            if(EditWindow._entity is Faculty faculty)
            {
                if (context.Faculties.Contains(faculty))
                {
                    var choosedFaculty = context.Faculties.FirstOrDefault(f => f.FacultyId == faculty.FacultyId);

                    choosedFaculty.FacultyName = editedText[0];
                    choosedFaculty.Department = editedText[1];
                    choosedFaculty.Note = editedText[2];
                    access.GetFaculties();
                }

            }

            if (EditWindow._entity is Group group)
            {
                if (context.Groups.Contains(group))
                {
                    var choosedGroup = context.Groups.FirstOrDefault(g => g.GroupId == group.GroupId);

                    choosedGroup.GroupName = editedText[0];
                    choosedGroup.Faculty = editedText[1];
                    choosedGroup.AmountOfStudents = int.Parse(editedText[2]);
                    choosedGroup.GroupAverage = double.Parse(editedText[3]);
                    access.GetGroups();

                }

            }

            if (EditWindow._entity is Student student)
            {
                if (context.Students.Contains(student))
                {
                    var choosedStudent = context.Students.FirstOrDefault(s => s.RegistrationDate == student.RegistrationDate);

                    choosedStudent.Surname = editedText[0];
                    choosedStudent.Name = editedText[1];
                    choosedStudent.GroupName = editedText[2];
                    choosedStudent.AverageScore = double.Parse(editedText[3]);
                    access.GetStudents();

                }

            }
            context.SaveChanges();

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }

        }
        private void CancelButton(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
