using RunningApp.ApplicationCore;
namespace RunningApp;
public class RunningInfo : BaseEntity
{
    public double Distance { get; set; }
    public int Tempo { get; set; }
    public string Track { get; set; }
    public DateTime StartTime { get; set; }
    public User User { get; set; }
    public List<User> Users { get; set; }
}
//starttime
//track
//tempo
//user.id
