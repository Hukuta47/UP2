using RepairTrack.Database;
using System.Windows;
using System.Windows.Controls;

namespace RepairTrack.Pages
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users()
            {
                Username = Textbox_Username.Text,
                Password = PasswordBox_SecondPassword.Password,
                RoleID = 3,
                Name = Textbox_Name.Text,
                ContactInfo = TextBox_ContactInfo.Text
            };
            App.dBEntities.Users.Add(user);
            App.dBEntities.SaveChanges();
        }
    }
}
