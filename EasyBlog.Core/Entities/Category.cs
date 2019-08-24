using System.Collections.Generic;

namespace EasyBlog.Core.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
