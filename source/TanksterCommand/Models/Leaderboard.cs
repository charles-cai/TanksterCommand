namespace TanksterCommand.Models
{
    using System.Collections.Generic;

    public class Leaderboard
    {
        public IEnumerable<Profile> Scores { get; set; }
    }
}