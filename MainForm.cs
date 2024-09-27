using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace Query_Database
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();  // This method initializes all controls on the form
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 450);
            this.dataGridView1.TabIndex = 0;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Query Results";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView1;


        private void MainForm_Load(object sender, EventArgs e)
        {
            // Connection string for SQL Server
            string connectionString = "Server=HFMS-5CG9254D8Q;Database=AdventureWorks2022;Integrated Security=True;";

            // SQL query to fetch data
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

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Convert DataTable to JSON and save to file
                    string json = DataTableToJson(dataTable);
                    string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "output.json");
                    File.WriteAllText(filePath, json);

                    // Show message that the JSON file was saved
                    MessageBox.Show($"Data exported to JSON file: {filePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
       // This method takes a DataTable and converts it to a JSON string
    private string DataTableToJson(DataTable dataTable)
{
    // Fully qualify the Formatting enum to avoid ambiguity
    return Newtonsoft.Json.JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
}




        private void SaveDataTableToJsonFile(DataTable dataTable, string filePath)
        {
            // Convert the DataTable to a JSON string
            string json = DataTableToJson(dataTable);

            // Write the JSON string to a file
            File.WriteAllText(filePath, json);
        }

        // Helper method to convert DataTable to JSON
        //private string DataTableToJson(DataTable table)
        //{
        //    return JsonConvert.SerializeObject(table, Formatting.Indented);
        //}
    }
}
