using System;

namespace TicTacToeDomain
{
    public class Game : Entity
    {
        public DateTime MatchTime { get; set; }
        public Outcome Outcome { get; set; }
        public int PlayerId { get; set; }

        public Game()
        {
            
        }

        public Game(Outcome outcome, int playerId)
        {
            MatchTime = DateTime.Now;
            Outcome = outcome;
            PlayerId = playerId;
        }

        public Game(DateTime matchTime, Outcome outcome, int playerId)
        {
            MatchTime = matchTime;
            Outcome = outcome;
            PlayerId = playerId;
        }
    }
}