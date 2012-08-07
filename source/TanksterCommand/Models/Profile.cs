namespace TanksterCommand.Models
{
    public class Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Avatar { get; set; }

        public int Accuracy { get; set; }

        public int Kills { get; set; }

        public int Rank { get; set; }

        public int Terrain { get; set; }

        public bool InGame { get; set; }

        public int Victories { get; set; }

        public int XP { get; set; }
    }
}
