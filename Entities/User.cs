using System;
using System.ComponentModel.DataAnnotations;

namespace SecondDbProject.Entities
{
    public class User
    {
        public int Id { get; set; } 

        public string Username { get; set; }

        public string Email { get; set; }

        public List<Post>? Posts { get; set; } = new List<Post>();
    }
}
    
