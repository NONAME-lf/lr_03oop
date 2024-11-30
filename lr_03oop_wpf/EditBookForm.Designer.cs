namespace lr_03oop_wpf
{
    partial class EditBookForm
    {
        private TextBox textBoxAuthor;
        private TextBox textBoxTitle;
        private TextBox textBoxAnnotation;
        private TextBox textBoxQualification;
        private Button btnOk;
        private Button btnCancel;

        private void InitializeComponent()
        {
            textBoxAuthor = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 300, PlaceholderText = "Author" };
            textBoxTitle = new TextBox { Location = new System.Drawing.Point(20, 60), Width = 300, PlaceholderText = "Title" };
            textBoxAnnotation = new TextBox { Location = new System.Drawing.Point(20, 100), Width = 300, PlaceholderText = "Annotation" };
            textBoxQualification = new TextBox { Location = new System.Drawing.Point(20, 140), Width = 300, PlaceholderText = "Qualification" };

            btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(50, 200), DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(150, 200), DialogResult = DialogResult.Cancel };

            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;

            Controls.Add(textBoxAuthor);
            Controls.Add(textBoxTitle);
            Controls.Add(textBoxAnnotation);
            Controls.Add(textBoxQualification);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            Text = "Edit Book";
            Size = new System.Drawing.Size(350, 300);
        }
    }
}