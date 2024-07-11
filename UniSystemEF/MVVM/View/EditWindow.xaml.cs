using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using UniSystemEF.MVVM.ViewModel;

namespace UniSystemEF.MVVM.View
{
    public partial class EditWindow : Window
    {
        public static object _entity;
        public EditWindow()
        {
            InitializeComponent();
        }
    }
}
