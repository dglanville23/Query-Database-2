using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Data.SqlClient;
using System.Configuration;


namespace Query_Database_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MainForm_Load);

        }

        // This method is triggered when the form is loaded
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load data into the grid (you should implement the GetDataFromDatabase method)
            DataTable dataTable = GetDataFromDatabase(); // Your database fetch method
            dataGridView1.DataSource = dataTable;
            dataGridView2.DataSource = dataTable;

            string jsonFilePath = ConfigurationManager.AppSettings["JsonFilePath"];
            
            // Save the DataTable to a JSON file
            SaveDataTableToJsonFile(dataTable, jsonFilePath);

            //SendEmailWithAttachment("C:\\Software Development\\Files\\file.json");

        }

        // Method that converts DataTable to JSON
        private string DataTableToJson(DataTable dataTable)
        {
            return JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
        }

        // Method that saves DataTable to a JSON file
        private void SaveDataTableToJsonFile(DataTable dataTable, string jsonFilePath)
        {
            string json = DataTableToJson(dataTable);
            System.IO.File.WriteAllText(jsonFilePath, json);
        }

        // This is the method that handles sending the email when the button is clicked
        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            // Path to the JSON file
            string filePath = ConfigurationManager.AppSettings["JsonFilePath"];

            //string filePath = "C:\\Software Development\\Files\\output.json\";
            // Ensure the file exists before sending email
            if (System.IO.File.Exists(filePath))
            {
                SendEmailWithAttachment(filePath);
            }
            else
            {
                MessageBox.Show("JSON file not found. Please generate it first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method that sends an email with the JSON file attached

        private void SendEmailWithAttachment(string filePath)
        {
            try
            {

                // Create the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dglanville@gmail.com"); // Your email
                mail.To.Add("dglanville@gmail.com"); // Recipient's email
                mail.Subject = "JSON File Attachment";
                mail.Body = "Please find the attached JSON file.";

                // Attach the JSON file
                Attachment attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);

                // Set up the SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // Use Gmail SMTP server and port
                smtpClient.Credentials = new NetworkCredential("dglanville@gmail.com", "eqci zhqi aqhd rakp"); // Use App Password
                smtpClient.EnableSsl = true; // Enable SSL for secure connection

                // Send the email
                smtpClient.Send(mail);

                // Inform the user
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // You should implement this method to fetch data from the database
        private DataTable GetDataFromDatabase()
        {
            // Connection string for your SQL Server database
            string connectionString = "Server=HFMS-5CG9254D8Q;Database=AdventureWorks2022;Integrated Security=True;";

            // SQL query to fetch employee data
            string query = "SELECT [Name], [GroupName], [ModifiedDate] FROM [AdventureWorks2022].[HumanResources].[Department]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand
                    SqlCommand command = new SqlCommand(query, connection);

                    // Execute the query and load results into a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;

                    //// Bind the DataTable to the DataGridView
                    //dataGridView1.DataSource = dataTable;

                    //// Convert the DataTable to JSON
                    //string json = DataTableToJson(dataTable);

                    //// Specify the file path
                    //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "output.json");

                    //// Write JSON to a file
                    //System.IO.File.WriteAllText(filePath, json);

                    ////MessageBox.Show($"Data exported to JSON file: {filePath}");

                    //return  dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return new DataTable();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmailWithAttachment(ConfigurationManager.AppSettings["JsonFilePath"]);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); ;
        }
    }
}
