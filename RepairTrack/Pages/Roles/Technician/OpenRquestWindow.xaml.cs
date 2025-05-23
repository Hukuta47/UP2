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

namespace RepairTrack.Pages.Roles.Technician
{
    /// <summary>
    /// Логика взаимодействия для OpenRquestWindow.xaml
    /// </summary>
    public partial class OpenRquestWindow : Window
    {
        public string Text;
        public OpenRquestWindow(string Text)
        {
            InitializeComponent();
            TextBox_Description.Text = Text;
        }

        private void SaveDescription_Click(object sender, RoutedEventArgs e)
        {
            Text = TextBox_Description.Text;
            DialogResult = true;
        }
    }
}
