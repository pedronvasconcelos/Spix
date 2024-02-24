

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spix.Domain.Spixers;

namespace Spix.Infra.Database.Mapping;

public class SpixerMapping : IEntityTypeConfiguration<Spixer>
{
    public void Configure(EntityTypeBuilder<Spixer> builder)
    {
        builder.ToTable("spixers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Ignore(x => x._domainEvents);
        builder.Ignore(x => x.LikedByUsers);
        builder.Ignore(x => x.LikesCount);

        builder.Property(x => x.Content).HasColumnName("content");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.Active).HasColumnName("active");


    }
}
