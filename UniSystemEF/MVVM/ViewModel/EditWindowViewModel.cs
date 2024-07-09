using Microsoft.EntityFrameworkCore;
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
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        private string _editText;

        public string EditText
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
            // придумати як передати об"єкт рядка в цей метод, порівняти його
            // з типом факультету і зробити відповідні дії для редагування рядку

            DataContext context = DataContext.Instance;
            string Text = (string)parameter;
            string[] editedText = Text.Split(';');


            if(EditWindow._entity is Faculty faculty)
            {
                if (context.Faculties.Contains(faculty))
                {
                    var choosedFaculty = context.Faculties.FirstOrDefault(f => f.FacultyId == faculty.FacultyId);

                    choosedFaculty.FacultyId = int.Parse(editedText[0]);
                    choosedFaculty.FacultyName = editedText[1];
                    choosedFaculty.Department = editedText[2];
                    choosedFaculty.Note = editedText[3];
                }

            }

            context.SaveChanges();
            
           
        }
        private void CancelButton(object parameter)
        {
            if (parameter is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
