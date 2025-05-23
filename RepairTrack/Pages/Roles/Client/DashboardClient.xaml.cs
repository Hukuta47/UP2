using RepairTrack.Database;
using System.Linq;
using System.Text;
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
        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new CreateRequestPage(User));
        }
        private void RefreshTable_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_RequestList.ItemsSource = App.dBEntities.Request.Where(request => request.ClientID == User.UserID).ToList();
        }
    }
}
