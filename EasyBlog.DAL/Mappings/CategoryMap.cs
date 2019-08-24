using EasyBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBlog.DAL.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Description)
                .IsRequired(false);
        }
    }
}
