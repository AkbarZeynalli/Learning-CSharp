namespace LibraryManagementSystemm.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }     
        public string Email { get; set; }         
        public string Phone { get; set; }        
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;

        public ICollection<BorrowRecord> BorrowRecords { get; set; }
    }

}
