using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicTacToeDomain
{
    public class Entity
    {
        public int Id { get; set; }
        public Entity()
        {
            
        }
        public Entity(int id)
        {
            Id = id;
        }
    }
}
