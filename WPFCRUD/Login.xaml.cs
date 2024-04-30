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

namespace WPFCRUD
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly string[] imagePaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        private int currentIndex = 0;
        public Login()
        {
            InitializeComponent();
            SetNextImage();
        }
        private void SetNextImage()
        {
            try
            {
                DynamicImage.Source = new BitmapImage(new Uri(imagePaths[currentIndex], UriKind.Relative));
                currentIndex = (currentIndex + 1) % imagePaths.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }
        private void LoginButton_Click(object sender, object e)
        {
            // Add login logic here
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Example: Check if username and password are valid
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
