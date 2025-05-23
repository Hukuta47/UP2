using RepairTrack.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepairTrack.Pages.Roles.Manager
{
    public partial class SelectTechnicianWindow : Window
    {
        public Users SelectedUser;
        public SelectTechnicianWindow()
        {
            InitializeComponent();
            DataGrid_SelectTechnician.ItemsSource = App.dBEntities.GetTechniciansWithRequestCount().ToList();
        }

        private void SelectTechnician_Click(object sender, RoutedEventArgs e)
        {
            int SelectedUserID = ((sender as Button).DataContext as GetTechniciansWithRequestCount_Result).TechnicianID;
            SelectedUser = App.dBEntities.Users.First(user => user.UserID == SelectedUserID);
            DialogResult = true;
        }
    }
}
