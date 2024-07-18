using System.Windows;
using UniSystemEF.Data;
using UniSystemEF.MVVM.ViewModel;

namespace UniSystemEF
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        private readonly DataAccess access;

        public MainWindow()
        {
            InitializeComponent();

            access = DataAccess.Instance;
            viewModel = new MainWindowViewModel();

            DataContext = viewModel;

            GroupsGrid.ItemsSource = viewModel.Groups;
            FacultiesGrid.ItemsSource = viewModel.Faculties;
            StudentsGrid.ItemsSource = viewModel.Students;

            MainWindowViewModel.LoadData();
        }
    }
}
 