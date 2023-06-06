using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }

        public User() { }

        public User(string id, string name, string lastName, string email, string username, string password, string tipo)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Username: {Username}\n" +
                   $"Password: {Password}\n" +
                   $"Tipo: {Tipo}";
        }

    }
}
