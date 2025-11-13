namespace LibraryManagementSystemm.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Author { get; set; }  
        public string ISBN { get; set; }  // Beynəlxalq kitab nömrəsi
        public int TotalCopies { get; set; }  // Ümumi say
        public int AvailableCopies { get; set; }  // Hal-hazırda olan kitab sayı

        // 🔹 Əlaqə
        public int LibraryId { get; set; }  // Hansi kitabxanaya aid
        public Library Library { get; set; }
    }
}
