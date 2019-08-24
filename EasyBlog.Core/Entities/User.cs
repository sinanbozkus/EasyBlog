using System.Collections.Generic;

namespace EasyBlog.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
