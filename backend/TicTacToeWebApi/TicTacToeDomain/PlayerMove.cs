namespace TicTacToeDomain
{
    public class PlayerMove
    {
        public int SquareIndex { get; set; }

        public PlayerMove()
        {
        }

        public PlayerMove(int squareIndex)
        {
            SquareIndex = squareIndex;
        }

    }
}