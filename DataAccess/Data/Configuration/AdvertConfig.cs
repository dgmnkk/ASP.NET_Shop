using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Data.Entities;

namespace ShopApp.Data.Configuration
{
    public class AdvertConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasOne(x => x.Seller)
                .WithMany(x => x.Advertisements)
                .HasForeignKey(x => x.SellerId);
        }
    }
}
