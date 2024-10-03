namespace Query_Database_2
{
    partial class MainForm
    {

    private System.ComponentModel.IContainer components = null;

        // This method is automatically generated to initialize the form's components
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
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
            dataGridView2.Size = new Size(488, 523);
            dataGridView2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(611, 46);
            button1.Name = "button1";
            button1.Size = new Size(200, 93);
            button1.TabIndex = 1;
            button1.Text = "Send email";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(635, 428);
            button2.Name = "button2";
            button2.Size = new Size(170, 74);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(862, 601);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
    }
}
