using Model;
using System.Data.Entity.ModelConfiguration;

namespace Data.Configuration.PageRelated
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            this.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(p => p.Description)
                .IsRequired();

            this.Property(p => p.VisualUrl)
               .IsOptional();

            this.Property(p => p.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime");

            this.Property(p => p.ModifiedOn)
                .IsRequired()
                .HasColumnType("datetime");

        }
    }
}
