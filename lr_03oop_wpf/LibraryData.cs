namespace lr_03oop_wpf
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
        public string Qualification { get; set; }
    
        // Інформація про читача
        public string ReaderName { get; set; }
        public string ReaderFaculty { get; set; }
        public string ReaderDepartment { get; set; }
        public string ReaderPosition { get; set; }
    }


    public class LibraryData
    {
        public List<Book> Books { get; set; } = new();
    }
}