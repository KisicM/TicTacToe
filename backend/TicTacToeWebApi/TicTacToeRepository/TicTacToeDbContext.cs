using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using TicTacToeDomain;

namespace TicTacToeRepository
{
    public class TicTacToeDbContext : DbContext
    {
        public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options) : base(options)
        {
        }

        public TicTacToeDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasData(
                    new User()
                    {
                        Id = -1,
                        Username = "mkisic",
                        Password = "ftn",
                        Email = "mkisic99@gmail.com",
                        Name = "Mihajlo",
                        Surname = "Kisic"
                    }
                );
            });

            modelBuilder.Entity<Game>(game =>
            {
                game.HasData(
                    new Game()
                    {
                        Id = -1,
                        MatchTime = DateTime.Now,
                        PlayerId = -1,
                        Outcome = Outcome.DRAW
                    }
                );
            });

            modelBuilder.Entity<PlayerRoom>(room =>
            {
                room.HasData(
                    new PlayerRoom()
                    {
                        Id = -1,
                        Name = "room1",
                        FirstPlayer = -1,
                        SecondPlayer = -1
                    }
                );
            });
        }
    }
}