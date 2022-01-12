using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UTB.Eshop.Web.Models.Entity;

namespace UTB.Eshop.Web.Models.Database.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(nameof(Rating.DateTimeCreated))
                .HasDefaultValueSql("NOW(6)");
        }
    }
}
