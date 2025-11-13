namespace LibraryManagementSystemm.Models
{
    //Hansı üzvün hansı kitabı nə vaxt götürdüyünü və nə vaxt qaytardığını göstərir
    public class BorrowRecord
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }  // null = hələ qaytarılmayıb
        public bool IsReturned { get; set; } = false;

    }
}
