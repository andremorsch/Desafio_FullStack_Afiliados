using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data
{
    public class AffiliateDataMap : IEntityTypeConfiguration<AffiliateData>
    {
        public void Configure(EntityTypeBuilder<AffiliateData> builder)
        {
            builder.ToTable("Affiliates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60);

            builder.Property(x => x.Product)
                .IsRequired()
                .HasColumnName("Product")
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Value")
                .HasColumnType("DECIMAL(18,2)");

            builder.Property(x => x.Seller)
                .IsRequired()
                .HasColumnName("Seller")
                .HasColumnType("NVARCHAR");
        }
    }
}
