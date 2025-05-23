using RepairTrack.Database;
using System.Windows;
using System.Windows.Controls;

namespace RepairTrack.Pages.Roles.Client
{
    public partial class CreateRequestPage : Page
    {
        Users user;
        public CreateRequestPage(Users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void CreateRequest_Button(object sender, RoutedEventArgs e)
        {
            App.dBEntities.CreateRepairRequest(1,1, TextBox_Desription.Text, user.UserID);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.GoBack();
        }
    }
}
