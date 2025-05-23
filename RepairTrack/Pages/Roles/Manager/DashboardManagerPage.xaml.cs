using System.Linq;

using System.Windows.Controls;


namespace RepairTrack.Pages.Roles.Manager
{
    /// <summary>
    /// Логика взаимодействия для DashboardManagerPage.xaml
    /// </summary>
    public partial class DashboardManagerPage : Page
    {
        public DashboardManagerPage()
        {
            InitializeComponent();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ExecutorID == null).ToList();
        }
    }
}
