namespace lr_03oop_wpf
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
        public string Qualification { get; set; }
    }
    
    public class LibraryData
    {
        public List<Book> Books { get; set; } = new();
    }
}