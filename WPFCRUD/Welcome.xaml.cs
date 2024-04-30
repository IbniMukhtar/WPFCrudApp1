using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;


namespace WPFCRUD
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private void NavigateToLogin(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Navigate to Login.xaml page within the same window
                Login login = new Login();
                this.Content = login;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Demo page: {ex.Message}");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the Login page
            NavigationService.Navigate(new Login());
        }
    }
}
