using EasyBlog.Domain.Enums;
using System.Collections.Generic;

namespace EasyBlog.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
