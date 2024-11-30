namespace lr_03oop_wpf
{
    partial class AboutForm
    {
        private void InitializeComponent()
        {
            Label aboutLabel = new Label
            {
                Text = "Done by: Artemii Mekshakov\nCourse: 2\nGroup: K-23\nYear: 2024\nDescription: JSON File Manager",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };

            Button closeButton = new Button
            {
                Text = "Close",
                Location = new System.Drawing.Point(20, 100),
                DialogResult = DialogResult.OK
            };

            Controls.Add(aboutLabel);
            Controls.Add(closeButton);

            Text = "About";
            Size = new System.Drawing.Size(300, 200);
        }
    }
}