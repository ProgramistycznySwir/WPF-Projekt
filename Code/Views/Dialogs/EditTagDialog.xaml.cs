using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Project.Models.Database;

namespace WPF_Project.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for NewTagDialog.xaml
    /// </summary>
    public partial class EditTagDialog : Window
    {
        public EditTagDialog(Tag tag)
        {
            InitializeComponent();

            base.DataContext = tag;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e) => base.DialogResult = false;
        private void btn_Save_Click(object sender, RoutedEventArgs e) => base.DialogResult = true;
    }
}
