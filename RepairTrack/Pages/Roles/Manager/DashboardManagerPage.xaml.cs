using RepairTrack.Database;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace RepairTrack.Pages.Roles.Manager
{
    public partial class DashboardManagerPage : Page
    {
        Users user;
        public DashboardManagerPage(Users user)
        {
            InitializeComponent();
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ExecutorID == null).ToList();
            this.user = user;
        }
        private void SelectTechnicianToRequest_Click(object sender, RoutedEventArgs e)
        {
            Request request = ((sender as Button).DataContext as Request);
            SelectTechnicianWindow windowDialog = new SelectTechnicianWindow();

            if (windowDialog.ShowDialog() == true)
            {
                request.ExecutorID = windowDialog.SelectedUser.UserID;
                request.ManagerID = user.UserID;
                request.StatusID = 3;
                App.dBEntities.SaveChanges();
            }
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(_request => _request.ExecutorID == null).ToList();
        }

        private void RequestCheck_Click(object sender, RoutedEventArgs e)
        {
            Request request = (sender as Button).DataContext as Request;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Устройство: {request.Device.TypeDevice.Name}");
            stringBuilder.AppendLine($"Проблема: {request.Issue.Name}");
            stringBuilder.AppendLine($"Статус: {request.Statuses.Name}");
            stringBuilder.AppendLine("Описание: " + (request.Description != null ? request.Description : "Пока нету"));
            stringBuilder.AppendLine("Менеджер: " + (request.Users1 != null ? request.Users1.Username : "Пока не назначен"));
            stringBuilder.AppendLine("Техник: " + (request.Users != null ? request.Users.Username : "Пока не назначен"));
            stringBuilder.AppendLine("Примерная дата завершения работы: " + request.Deadline.Value.ToShortDateString());

            MessageBox.Show(stringBuilder.ToString());

        }
    }
}
