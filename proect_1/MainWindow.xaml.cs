using proect_1.Core;
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
using System.Windows.Shapes;
using proect_1.Model;

namespace proect_1.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CoreDbConnect.DB = new Model.Entities();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = CoreDbConnect.DB.Users.FirstOrDefault(u => u.UserLogin == TbLogin.Text && u.UserPassword == PbPassword.Password);
                if (userModel != null)
                {
                    switch (userModel.RoleID)
                    {
                        case 1:
                            new AdminWindow().ShowDialog();
                            break;

                        case 2:
                            new UserWindow().ShowDialog();
                            break;

                        case 3:
                            new DevWindow().ShowDialog();
                            break;
                    }
                }
                else
                {
                    new Window1().ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                new Window1().ShowDialog();
            }
        }

        private void BtnAdminInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "adm";
            PbPassword.Password = "123Adm";
        }

        private void BtnDevInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "timdev";
            PbPassword.Password = "321D";
        }

        private void BtnUseerInfo_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "user0";
            PbPassword.Password = "0123U";
        }

        private void BtnClean_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Text = "";
            PbPassword.Password = "";
        }
    }
}
