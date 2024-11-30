namespace lr_03oop_wpf
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private Button searchButton;
        private TextBox searchTextBox;
        private Button openButton;
        private Button saveButton;
        private Button exportButton;
        private Button aboutButton;
        
        private void InitializeComponent()
        {
            this.dataGridView = new DataGridView();
            this.addButton = new Button();
            this.editButton = new Button();
            this.deleteButton = new Button();
            this.searchButton = new Button();
            this.searchTextBox = new TextBox();
            this.openButton = new Button();
            this.saveButton = new Button();
            this.exportButton = new Button();
            this.aboutButton = new Button();
            
            // DataGridView
            this.dataGridView.Location = new System.Drawing.Point(12, 37);
            this.dataGridView.Size = new System.Drawing.Size(845, 270);

            // SearchTextBox
            this.searchTextBox.Location = new System.Drawing.Point(12, 320);
            this.searchTextBox.Size = new System.Drawing.Size(400, 23);
            
            // SearchButton
            this.searchButton.Text = "Search";
            this.searchButton.Location = new System.Drawing.Point(420, 320);
            this.searchButton.Click += (sender, args) => SearchBooks(searchTextBox.Text);

            // AddButton
            this.addButton.Text = "Add";
            this.addButton.Location = new System.Drawing.Point(10, 350);
            this.addButton.Click += (sender, args) => AddNewBook();


            // EditButton
            this.editButton.Text = "Edit";
            this.editButton.Location = new System.Drawing.Point(90, 350);
            this.editButton.Click += (sender, args) => EditSelectedBook();


            // DeleteButton
            this.deleteButton.Text = "Delete";
            this.deleteButton.Location = new System.Drawing.Point(170, 350);
            this.deleteButton.Click += (sender, args) => DeleteSelectedBook();

            // OpenButton
            this.openButton.Text = "Open";
            this.openButton.Location = new System.Drawing.Point(10, 10);
            this.openButton.Click += (sender, args) => OpenJsonFile();
            this.Controls.Add(this.openButton);

            // SaveButton
            this.saveButton.Text = "Save";
            this.saveButton.Location = new System.Drawing.Point(90, 10);
            this.saveButton.Click += (sender, args) => SaveJsonFile();
            this.Controls.Add(this.saveButton);
            
            // ExportButton
            this.exportButton.Text = "Export";
            this.exportButton.Location = new System.Drawing.Point(170, 10);
            this.exportButton.Click += (sender, args) => ExportJsonFile();
            this.Controls.Add(this.exportButton);
            
            // AboutButton
            this.aboutButton.Text = "About";
            this.aboutButton.Location = new System.Drawing.Point(250, 10);
            this.aboutButton.Click += (sender, args) => new AboutForm().ShowDialog();
            this.Controls.Add(this.aboutButton);
            
            // Form
            this.ClientSize = new System.Drawing.Size(900, 400);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Text = "Library JSON Manager";
        }
    }
}
