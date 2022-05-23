using System.Security.Principal;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicTacToeDomain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public User()
        {
            
        }

        public User(string username, string password, string name, string surname, string email)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}