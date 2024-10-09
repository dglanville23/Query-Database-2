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
            lstWeather = new ListView();
            label1 = new Label();
            lstView = new ListView();
            lstView2 = new ListView();
            Description = new ColumnHeader();
            Value = new ColumnHeader();
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
            dataGridView2.Location = new Point(50, 95);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 72;
            dataGridView2.Size = new Size(373, 371);
            dataGridView2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(446, 477);
            button1.Name = "button1";
            button1.Size = new Size(200, 42);
            button1.TabIndex = 1;
            button1.Text = "Send email";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(850, 477);
            button2.Name = "button2";
            button2.Size = new Size(177, 39);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // fetchWeatherButton
            // 
            fetchWeatherButton.Location = new Point(652, 477);
            fetchWeatherButton.Name = "fetchWeatherButton";
            fetchWeatherButton.Size = new Size(192, 39);
            fetchWeatherButton.TabIndex = 3;
            fetchWeatherButton.Text = "Fetch Weather";
            fetchWeatherButton.UseVisualStyleBackColor = true;
            fetchWeatherButton.Click += fetchWeatherButton_Click_1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(652, 54);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(168, 35);
            txtCity.TabIndex = 4;
            // 
            // lstWeather
            // 
            lstWeather.GridLines = true;
            lstWeather.Location = new Point(1195, 373);
            lstWeather.Name = "lstWeather";
            lstWeather.Size = new Size(83, 54);
            lstWeather.TabIndex = 5;
            lstWeather.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(532, 54);
            label1.Name = "label1";
            label1.Size = new Size(102, 30);
            label1.TabIndex = 6;
            label1.Text = "Enter City";
            label1.Click += label1_Click;
            // 
            // lstView
            // 
            lstView.Location = new Point(487, 619);
            lstView.Name = "lstView";
            lstView.Size = new Size(206, 91);
            lstView.TabIndex = 7;
            lstView.UseCompatibleStateImageBehavior = false;
            // 
            // lstView2
            // 
            lstView2.Columns.AddRange(new ColumnHeader[] { Description, Value });
            lstView2.Location = new Point(446, 105);
            lstView2.Name = "lstView2";
            lstView2.Size = new Size(581, 361);
            lstView2.TabIndex = 8;
            lstView2.UseCompatibleStateImageBehavior = false;
            lstView2.View = View.Details;
            // 
            // Description
            // 
            Description.Width = 150;
            // 
            // Value
            // 
            Value.Width = 100;
            // 
            // MainForm
            // 
            ClientSize = new Size(1647, 601);
            Controls.Add(lstView2);
            Controls.Add(lstView);
            Controls.Add(label1);
            Controls.Add(lstWeather);
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
        private ListView lstWeather;
        private Label label1;
        private ListView lstView;
        private ListView lstView2;
        private ColumnHeader Description;
        private ColumnHeader Value;
    }
}
