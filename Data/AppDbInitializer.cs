using RunningApp.ApplicationCore;

namespace RunningApp.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
        {
            var context = serviceScope.ServiceProvider.GetService<EfContex>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        FirstName = "Omar",
                        LastName = "Mohanned",
                        NickName = "Omarinho",
                        Email = "Omar@hotmail.com",
                        ProfilePicture = "https://previews.123rf.com/images/aurielaki/aurielaki1606/aurielaki160600025/58881133-running-winner-athletics-summer-games-icon-set-winning-concept-3d-isometric-win-runner-athlete-sport.jpg",

                    },

                    new User()
                    {
                        FirstName = "Marcus",
                        LastName = "Sakae",
                        NickName = "SUGOIBOY",
                        Email = "Marcu@hotmail.com",
                        ProfilePicture = "https://previews.123rf.com/images/aurielaki/aurielaki1606/aurielaki160600025/58881133-running-winner-athletics-summer-games-icon-set-winning-concept-3d-isometric-win-runner-athlete-sport.jpg",
                    }
                });
                context.SaveChanges();
            }
            if (!context.RunningInfos.Any())
            {
                context.RunningInfos.AddRange(new List<RunningInfo>()
                    {
                        new RunningInfo()
                        {
                            Distance = 4.5,
                            Tempo = 7,
                            StartTime = DateTime.Now,
                            User = context.Users.FirstOrDefault(),
                            Users = new(),
                        }
                    });
                context.SaveChanges();

            }
        }
    }
}