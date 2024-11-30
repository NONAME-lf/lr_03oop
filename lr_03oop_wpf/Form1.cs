using System;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace lr_03oop_wpf
{
    public partial class Form1 : Form
    {
        private const string FilePath = "data.json";
        private LibraryData _libraryData;
        private string _currentFilePath;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            UpdateGrid();
        }

        private void OpenJsonFile()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Open JSON File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        string jsonData = File.ReadAllText(filePath);
                        _libraryData = JsonSerializer.Deserialize<LibraryData>(jsonData);
                        _currentFilePath = filePath; // Remember path for files
                        UpdateGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ExportJsonFile()
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.Title = "Export JSON File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string jsonData = JsonSerializer.Serialize(_libraryData, new JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(saveFileDialog.FileName, jsonData);
                        MessageBox.Show("File exported successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to export file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveJsonFile()
        {
            if (string.IsNullOrEmpty(_currentFilePath))
            {
                MessageBox.Show("No file is currently open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string jsonData = JsonSerializer.Serialize(_libraryData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_currentFilePath, jsonData);
                MessageBox.Show("File saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void LoadData()
        {
            _libraryData = JsonHelper.LoadFromFile(FilePath);
        }

        private void SaveData()
        {
            JsonHelper.SaveToFile(FilePath, _libraryData);
        }

        private void UpdateGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = _libraryData.Books;
        }

        private void AddNewBook()
        {
            using (var addForm = new EditBookForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    var newBook = new Book
                    {
                        Author = addForm.Author,
                        Title = addForm.Title,
                        Annotation = addForm.Annotation,
                        Qualification = addForm.Qualification
                    };
                    
                    _libraryData.Books.Add(newBook);
                    SaveData(); // Save to JSON
                    UpdateGrid(); // Updating grid
                }
            }
        }
        
        private void EditSelectedBook()
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dataGridView.CurrentRow.Index;
            var book = _libraryData.Books[index];

            using (var editForm = new EditBookForm(book.Author, book.Title, book.Annotation, book.Qualification))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Оновлюємо дані книги
                    book.Author = editForm.Author;
                    book.Title = editForm.Title;
                    book.Annotation = editForm.Annotation;
                    book.Qualification = editForm.Qualification;

                    SaveData(); // Зберігаємо дані до JSON
                    UpdateGrid(); // Оновлюємо таблицю
                }
            }
        }
        
        private void DeleteBook(int index)
        {
            if (index < 0 || index >= _libraryData.Books.Count) return;
            _libraryData.Books.RemoveAt(index);
            SaveData(); // Save to JSON
            UpdateGrid(); // Updating grid
        }
        
        private void DeleteSelectedBook()
        {
            if (dataGridView.CurrentRow == null) return; // Check for row
            int index = dataGridView.CurrentRow.Index;
            DeleteBook(index);
        }

        
        private void SearchBooks(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                dataGridView.DataSource = _libraryData.Books;
                return;
            }

            var filteredBooks = _libraryData.Books.Where(book =>
                    book.Author.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    book.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    book.Qualification.Contains(query, StringComparison.OrdinalIgnoreCase) // Пошук за Qualification
            ).ToList();

            dataGridView.DataSource = null;
            dataGridView.DataSource = filteredBooks;
        }

    }
}
