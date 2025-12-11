using FMS.DAL.Models;

public class Player : BaseEntity
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ShirtNumber { get; set; }

    public int ClubId { get; set; }
    public Club Club { get; set; }

    public string Position { get; set; }  // Yalnız string saxla
    // public int PositionId { get; set; }  // Silindi

    public List<Goal> Goals { get; set; }
}
