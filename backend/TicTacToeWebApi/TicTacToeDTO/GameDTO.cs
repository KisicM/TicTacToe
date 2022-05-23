using TicTacToeDomain;

namespace TicTacToeDTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public int SquareIndex { get; set; }
        public int Outcome { get; set; }
        public int PlayerId { get; set; }
        public string RoomId { get; set; }
    }
}