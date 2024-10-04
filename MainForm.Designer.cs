namespace Query_Database_2
{
    partial class MainForm
    {

    private System.ComponentModel.IContainer components = null;

        // This method is automatically generated to initialize the form's components
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            fetchWeatherButton = new Button();
            txtCity = new TextBox();
            toolTip1 = new ToolTip(components);
            listView1 = new ListView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(760, 450);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(45, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 72;
            dataGridView2.Size = new Size(428, 523);
            dataGridView2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(889, 41);
            button1.Name = "button1";
            button1.Size = new Size(200, 93);
            button1.TabIndex = 1;
            button1.Text = "Send email";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(919, 276);
            button2.Name = "button2";
            button2.Size = new Size(170, 74);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fetchWeatherButton
            // 
            fetchWeatherButton.Location = new Point(897, 149);
            fetchWeatherButton.Name = "fetchWeatherButton";
            fetchWeatherButton.Size = new Size(192, 43);
            fetchWeatherButton.TabIndex = 3;
            fetchWeatherButton.Text = "NYC Weather";
            fetchWeatherButton.UseVisualStyleBackColor = true;
            fetchWeatherButton.Click += fetchWeatherButton_Click_1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(539, 41);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(168, 35);
            txtCity.TabIndex = 4;
            // 
            // listView1
            // 
            listView1.Location = new Point(539, 92);
            listView1.Name = "listView1";
            listView1.Size = new Size(275, 371);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            ClientSize = new Size(1647, 601);
            Controls.Add(listView1);
            Controls.Add(txtCity);
            Controls.Add(fetchWeatherButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private Button fetchWeatherButton;
        private TextBox txtCity;
        private ToolTip toolTip1;
        private ListView listView1;
    }
}
