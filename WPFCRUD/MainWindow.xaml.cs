using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using System.Windows.Navigation;
namespace WPFCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "Data Source=DESKTOP-JMR591K\\SQLEXPRESS;Initial Catalog=WPFCRUDAppDb;Integrated Security=True;Trust Server Certificate=True";
        public MainWindow()
        {
            InitializeComponent();
            DisplayData();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void clrBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData(); 
        }
        public void clearData()
        {
            name_txt.Clear();
            age_txt.Clear();
            gender_txt.Clear();
            city_txt.Clear();
        }
        private void addBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string sql = "INSERT INTO tbl_1 (Name, Age, Gender, City) VALUES (@Name, @Age, @Gender, @City)";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name_txt.Text);
                            command.Parameters.AddWithValue("@Age", age_txt.Text);
                            command.Parameters.AddWithValue("@Gender", gender_txt.Text);
                            command.Parameters.AddWithValue("@City", city_txt.Text);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Record inserted successfully.");
                        DisplayData();
                        clearData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private bool isValid()
        {
            return !string.IsNullOrEmpty(name_txt.Text) &&
                   !string.IsNullOrEmpty(age_txt.Text) &&
                   !string.IsNullOrEmpty(gender_txt.Text) &&
                   !string.IsNullOrEmpty(city_txt.Text);
        }
        private void DisplayData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM tbl_1";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    datagrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        /*  private void updateBtn_Click(object sender, RoutedEventArgs e)
          {
              DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;
              if (selectedRow != null)
              {
                  if (isValid())
                  {
                      using (SqlConnection connection = new SqlConnection(connectionString))
                      {
                          try
                          {
                              connection.Open();
                              string sql = "UPDATE tbl_1 SET Name = @Name, Age = @Age, Gender = @Gender, City = @City WHERE Id = @Id";
                              using (SqlCommand command = new SqlCommand(sql, connection))
                              {
                                  command.Parameters.AddWithValue("@Name", name_txt.Text);
                                  command.Parameters.AddWithValue("@Age", age_txt.Text);
                                  command.Parameters.AddWithValue("@Gender", gender_txt.Text);
                                  command.Parameters.AddWithValue("@City", city_txt.Text);
                                  command.Parameters.AddWithValue("@Id", selectedRow["Id"]);
                                  command.ExecuteNonQuery();
                              }
                              MessageBox.Show("Record updated successfully.");
                              DisplayData();
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show($"Error: {ex.Message}");
                          }
                      }
                  }
                  else
                  {
                      MessageBox.Show("Please fill in all fields.");
                  }
              }
              else
              {
                  MessageBox.Show("Please select a row to update.");
              }
          }*/

        private void deleteBtn_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;
            if (selectedRow != null)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string sql = "DELETE FROM tbl_1 WHERE Id = @Id";
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@Id", selectedRow["Id"]);
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Record deleted successfully.");
                            clearData();
                            DisplayData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;
            if (selectedRow != null)
            {
                name_txt.Text = selectedRow["Name"].ToString();
                age_txt.Text = selectedRow["Age"].ToString();
                gender_txt.Text = selectedRow["Gender"].ToString();
                city_txt.Text = selectedRow["City"].ToString();
            }
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)datagrid.SelectedItem;
            if (selectedRow != null)
            {
                if (isValid())
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();
                            string sql = "UPDATE tbl_1 SET Name = @Name, Age = @Age, Gender = @Gender, City = @City WHERE Id = @Id";
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@Name", name_txt.Text);
                                command.Parameters.AddWithValue("@Age", age_txt.Text);
                                command.Parameters.AddWithValue("@Gender", gender_txt.Text);
                                command.Parameters.AddWithValue("@City", city_txt.Text);
                                command.Parameters.AddWithValue("@Id", selectedRow["Id"]);
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("Record updated successfully.");
                            clearData();
                            DisplayData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }
        private void NavigateToDemo(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Navigate to Demo.xaml page within the same window
                Welcome demoPage = new Welcome(); 
                this.Content = demoPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Demo page: {ex.Message}");
            }
        }

    }
}