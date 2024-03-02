using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spix.Domain.Constants;
using Spix.Domain.Entities;
namespace Spix.Infra.Database.Mapping;

public class SpixerMapping : IEntityTypeConfiguration<Spixer>
{
    public void Configure(EntityTypeBuilder<Spixer> builder)
    {
        builder.ToTable("spixers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("spixer_id");

        builder.Property(x => x.Content)
            .HasColumnName("content")
            .HasColumnType("varchar")
            .HasMaxLength(SpixerConstants.MaxContentLength);

        builder.Property(x => x.LikesCount)
        .HasColumnName("likes_count")
        .HasDefaultValue(0);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
              .HasConversion(v => v.ToUniversalTime(),
          v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); ;

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");

        builder.Property(x => x.Active)
            .HasColumnName("active");


        builder.HasOne(x => x.User)
           .WithMany()
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.SpixerLikes)
             .WithOne(x => x.Spixer)
             .HasForeignKey(x => x.SpixerId)
             .OnDelete(DeleteBehavior.Cascade);

    }
}

