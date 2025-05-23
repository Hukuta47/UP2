using RepairTrack.Database;
using System.Linq;
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
            ComboBox_Device.ItemsSource = App.dBEntities.TypeDevice.ToList();
            
            this.user = user;
        }
        private void CreateRequest_Button(object sender, RoutedEventArgs e)
        {
            App.dBEntities.CreateRepairRequest((int)ComboBox_Device.SelectedValue, (int)ComboBox_Issue.SelectedValue, user.UserID);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.GoBack();
        }
        private void ComboBox_Device_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_Issue.ItemsSource = (ComboBox_Device.SelectedItem as TypeDevice).Issue.ToList();
            ComboBox_Issue.SelectedIndex = 0;
        }
    }
}
