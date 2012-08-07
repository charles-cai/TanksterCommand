namespace TanksterCommand.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TanksterCommand.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TanksterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TanksterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Profiles.AddOrUpdate(
              p => p.Id,
              new Profile { Id= 1, Name = "Aaron Hulett", Accuracy= 97, Kills= 991, Rank= 1, Terrain= 22,Victories= 32, XP= 69, InGame= true, Avatar = 1 },
              new Profile { Id = 2, Name = "Heidi Steen", Accuracy = 80, Kills = 756, Rank = 2, Terrain = 54, Victories = 13, XP = 88, InGame = false, Avatar = 2 },
              new Profile { Id = 3, Name = "Julian Isla", Accuracy = 92, Kills = 547, Rank = 3, Terrain = 23, Victories = 32, XP = 15, InGame = true, Avatar = 3 },
              new Profile { Id = 4, Name = "Bankov, Peter", Accuracy = 50, Kills = 256, Rank = 4, Terrain = 13, Victories = 65, XP = 63, InGame = false, Avatar = 4 },
              new Profile { Id = 5, Name = "Jaworski, Michal", Accuracy = 75, Kills = 743, Rank = 5, Terrain = 2, Victories = 23, XP = 55, InGame = false, Avatar = 5 },
              new Profile { Id = 6, Name = "Steele, Mark", Accuracy = 94, Kills = 946, Rank = 6, Terrain = 42, Victories = 54, XP = 41, InGame = false, Avatar = 3 },
              new Profile { Id = 7, Name = "Pelton, David", Accuracy = 77, Kills = 365, Rank = 7, Terrain = 32, Victories = 45, XP = 42, InGame = false, Avatar = 2 },
              new Profile { Id = 8, Name = "Ken Myer", Accuracy = 62, Kills = 937, Rank = 8, Terrain = 31, Victories = 77, XP = 22, InGame = false, Avatar = 5 },
              new Profile { Id = 9, Name = "Jeff Phillips", Accuracy = 91, Kills = 736, Rank = 9, Terrain = 21, Victories = 12, XP = 34, InGame = true, Avatar = 1 },
              new Profile { Id = 10, Name = "Jill Shrader", Accuracy = 95, Kills = 875, Rank = 10, Terrain = 28, Victories = 4, XP = 14, InGame = false, Avatar = 4 }
            );
            
        }
    }
}
