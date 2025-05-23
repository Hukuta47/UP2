using RepairTrack.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepairTrack.Pages.Roles.Client
{
    public partial class DashboardClient : Page
    {
        Users User;
        public DashboardClient(Users User)
        {
            this.User = User;
            InitializeComponent();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ClientID == User.UserID).ToList();
        }
        private void RequestCheck_Click(object sender, RoutedEventArgs e)
        {
            Request request = (sender as Button).DataContext as Request;

        }
        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new CreateRequestPage(User));
        }
        private void RefreshTable_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_RequestList.Items.Refresh();
        }
    }
}
