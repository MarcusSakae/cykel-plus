using RunningApp.ApplicationCore;
namespace RunningApp;
public class RunningInfo : BaseEntity
{
    public int Distance { get; set; }
    public int Tempo { get; set; }
    public DateTime StartTime { get; set; }
    public User User { get; set; }
    public List<User> users { get; set; }
}