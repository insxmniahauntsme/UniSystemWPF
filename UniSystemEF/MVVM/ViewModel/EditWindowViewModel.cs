using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using UniSystemEF.Commands;
using UniSystemEF.Data;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.MVVM.ViewModel
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {
        private string _editText;
        private object _editItem;

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
        public object EditItem
        {
            get { return _editItem; }
            set
            {
                if (_editItem != value)
                {
                    _editItem = value;
                    OnPropertyChanged(nameof(EditItem));
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
            if (_editItem is Faculty faculty)
            {
                faculty.FacultyName = EditText;
            }
            else if (_editItem is Group group)
            {
                group.GroupName = EditText;
            }
            else if (_editItem is Student student)
            {
                student.Name = EditText;
            }

            // Збереження змін
            DataContext _context = DataContext.Instance;
            _context.SaveChanges();

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
