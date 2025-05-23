using RepairTrack.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            InitializeComponent();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ExecutorID == User.UserID).ToList();
        }
    }
}
