namespace TicTacToeDomain
{
    public class PlayerRoom : Entity
    {
        public string Name { get; set; }
        public int FirstPlayer { get; set; }
        public int SecondPlayer { get; set; }

        public PlayerRoom()
        {
            
        }

        public PlayerRoom(string name, int firstPlayer, int secondPlayer)
        {
            Name = name;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }
    }
}