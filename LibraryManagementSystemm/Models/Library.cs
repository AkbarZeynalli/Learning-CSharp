namespace LibraryManagementSystemm.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Məs: "Central City Library"
        public string Location { get; set; }    // Məs: "Downtown, Baku"
        public string Phone { get; set; }       // Əlaqə nömrəsi
        public ICollection<Book> Books { get; set; }  // Kitablar (relationship)
    }
}
