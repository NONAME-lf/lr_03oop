using System;
using System.Windows.Forms;

namespace lr_03oop_wpf
{
    public partial class EditBookForm : Form
    {
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Annotation { get; private set; }
        public string Qualification { get; private set; }
        
        public EditBookForm()
            : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
            Text = "Add New Book";
        }

        public EditBookForm(string author, string title, string annotation, string qualification)
        {
            InitializeComponent();
            Author = author;
            Title = title;
            Annotation = annotation;
            Qualification = qualification;

            // Fill all the fields
            textBoxAuthor.Text = Author;
            textBoxTitle.Text = Title;
            textBoxAnnotation.Text = Annotation;
            textBoxQualification.Text = Qualification;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Save data from the fields
            Author = textBoxAuthor.Text;
            Title = textBoxTitle.Text;
            Annotation = textBoxAnnotation.Text;
            Qualification = textBoxQualification.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}