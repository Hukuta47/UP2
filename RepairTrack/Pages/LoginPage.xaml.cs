using RepairTrack.Database;
using RepairTrack.Pages.Roles.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepairTrack.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string InputUsername = Textbox_Username.Text;
            
            if (App.dBEntities.Users.ToList().Exists(user => user.Username == InputUsername))
            {
                string InputPassword = PasswordBox_Password.Password;
                if (App.dBEntities.Users.FirstOrDefault(user => user.Username == InputUsername).Password == InputPassword)
                {
                    Users User = App.dBEntities.Users.FirstOrDefault(user => user.Username == InputUsername);

                    switch (User.Role.Name)
                    {
                        case "Техник":
                            
                            break;
                        case "Менеджер":
                            break;
                        case "Клиент":
                            PageManager.FrameMain.Navigate(new DashboardClient(User));
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Пароль не верен");
                }
            }
            else
            {
                MessageBox.Show("Такого пользователя нет");
            }
        }

        private void Registartion_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new RegistrationPage());
        }
    }
}
