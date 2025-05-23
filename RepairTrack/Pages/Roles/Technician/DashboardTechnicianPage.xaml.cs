using RepairTrack.Database;
using System.Linq;
using System.Windows.Controls;


namespace RepairTrack.Pages.Roles.Technician
{
    /// <summary>
    /// Логика взаимодействия для DashboardTechnicianPage.xaml
    /// </summary>
    public partial class DashboardTechnicianPage : Page
    {
        Users User;
        public DashboardTechnicianPage(Users User)
        {
            this.User = User;
            InitializeComponent();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ExecutorID == User.UserID && request.StatusID == 3).ToList();
        }

        private void OpenRequest_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Request request = ((sender as Button).DataContext as Request);

            OpenRquestWindow openRquestWindow = new OpenRquestWindow(request.Description);
            if (openRquestWindow.ShowDialog() == true)
            {
                request.Description = openRquestWindow.Text;
                App.dBEntities.SaveChanges();
                DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(_request => _request.ExecutorID == User.UserID && _request.StatusID == 3).ToList();
            }
        }

        private void CompleteRequest_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Request request = ((sender as Button).DataContext as Request);

            request.StatusID = 4;
            App.dBEntities.SaveChanges();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(_request => _request.ExecutorID == User.UserID && _request.StatusID == 3).ToList();

        }
    }
}
