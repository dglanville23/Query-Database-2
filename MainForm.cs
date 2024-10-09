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
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;



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

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return new DataTable();
                }
            }
        }



        //public partial class MainForm : Form
        //    {


        // Event handler for the Fetch Weather button
        //private async void fetchWeatherButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get weather data for New York City
        //        string weatherData = await GetWeatherDataAsync("New York");
        //        MessageBox.Show(weatherData, "Weather Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error fetching weather data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmailWithAttachment(ConfigurationManager.AppSettings["JsonFilePath"]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); ;
        }


        // Event handler for the Fetch Weather button
        private async void fetchWeatherButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get weather data for New York City
                string weatherData = await GetWeatherDataAsync("New York");
                MessageBox.Show(weatherData, "Weather Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching weather data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Async method to fetch weather data from OpenWeatherMap API
        private async Task<string> GetWeatherDataAsync(string city)
        {
            string apiKey = ConfigurationManager.AppSettings["WeatherApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("Weather API key is not configured in App.config.");
            }

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Parse the response JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject weatherJson = JObject.Parse(jsonResponse);

                    // Extract necessary weather information
                    string description = weatherJson["weather"][0]["description"].ToString();
                    string temp = weatherJson["main"]["temp"].ToString();
                    string humidity = weatherJson["main"]["humidity"].ToString();

                    return $"Weather in {city}:\n" +
                           $"Description: {description}\n" +
                           $"Temperature: {temp}°C\n" +
                           $"Humidity: {humidity}%";
                }
                catch (HttpRequestException httpEx)
                {
                    throw new Exception($"Error with the HTTP request: {httpEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");
                }
            }
        }


        private async void fetchWeatherButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string city = txtCity.Text.Trim();

                if (string.IsNullOrEmpty(city))
                {
                    MessageBox.Show("Please enter a city name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string weatherData = await GetWeatherDataAsync(city);

                MessageBox.Show(weatherData, "Weather Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the ListBox before adding new data
                lstWeather.Items.Clear();
                // Clear the ListView before adding new data
                lstView2.Items.Clear();

                // Add the header (column names) in the ListBox
                lstWeather.Items.Add($"{"Description".PadRight(20)}{"Value".PadRight(20)}");
                lstWeather.Items.Add(new string('-', 40)); // Separator line

                // Add the formatted weather data to ListBox and ListView
                string[] wrappedData = FormatWeatherDataForListBox(weatherData);
                foreach (string line in wrappedData)
                {
                    string[] splitLine = line.Split(new[] { ':' }, 2);
                    if (splitLine.Length == 2)
                    {
                        string description = splitLine[0].Trim();
                        string value = splitLine[1].Trim();

                        // Check if the line contains temperature data
                        if (description.ToLower().Contains("temperature"))
                        {
                            // Parse Celsius value and calculate Fahrenheit
                            if (double.TryParse(value.Replace("°C", "").Trim(), out double celsius))
                            {
                                double fahrenheit = (celsius * 9 / 5) + 32;
                                value = $"{celsius}°C ({fahrenheit:F1}°F)";
                            }
                        }

                        // Format the columns: pad the first column (description) and second column (value) in ListBox
                        string formattedLine = $"{description.PadRight(20)}{value.PadRight(20)}";
                        lstWeather.Items.Add(formattedLine);

                        // Add to ListView as well (Description and Value as separate columns)
                        ListViewItem listViewItem = new ListViewItem(description);
                        listViewItem.SubItems.Add(value);
                        lstView2.Items.Add(listViewItem);
                    }
                    else
                    {
                        lstWeather.Items.Add(line); // Add unformatted if not split
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching weather data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to format and wrap the weather data for easier reading in the ListBox
        private string[] FormatWeatherDataForListBox(string weatherData)
        {
            // Split the string into lines based on the new line characters
            return weatherData.Split(new[] { '\n' }, StringSplitOptions.None);
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
















   
