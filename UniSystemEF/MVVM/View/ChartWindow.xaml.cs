using System.Windows;
using UniSystemEF.MVVM.ViewModel;
using UniSystemEF.MVVM.Model;

namespace UniSystemEF.MVVM.View
{
    public partial class ChartWindow : Window
    {
        public ChartWindow(List<Group> groups, Group selectedGroup)
        {
            InitializeComponent();
            DataContext = new ChartWindowViewModel(groups, selectedGroup);
        }
    }
}
