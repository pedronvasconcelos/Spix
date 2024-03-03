using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spix.Domain.Entities;

namespace Spix.Infra.Database.Mapping;
public class SpixerLikeMapping : IEntityTypeConfiguration<SpixerLike>
{

    public void Configure(EntityTypeBuilder<SpixerLike> builder)
    {
        builder
            .ToTable("spixer_likes");

        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasColumnName("like_id");

        builder.Property(x => x.SpixerId)
          .HasColumnName("spixer_id");

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");

        builder.Property(x => x.CreatedAt)
          .HasColumnName("created_at")
          .HasConversion(v => v.ToUniversalTime(),
          v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); 

        builder.HasOne(x => x.Spixer)
           .WithMany(s => s.SpixerLikes)
           .HasForeignKey(x => x.SpixerId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}