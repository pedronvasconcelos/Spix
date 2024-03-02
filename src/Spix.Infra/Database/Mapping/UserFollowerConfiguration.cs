using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spix.Domain.Entities;

namespace Spix.Infra.Database.Mapping;

public partial class UserMapping
{
    public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.ToTable("user_followers");

            builder.HasKey(uf => new { uf.UserId, uf.FollowerId });

            builder.Property(uf => uf.UserId)
                   .HasColumnName("user_id"); // Define the column name for UserId

            builder.Property(uf => uf.FollowerId)
                   .HasColumnName("follower_id"); // Define the column name for FollowerId

            builder.HasOne(uf => uf.User)
                   .WithMany(u => u.Followers)
                   .HasForeignKey(uf => uf.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uf => uf.Follower)
                   .WithMany(u => u.Following)
                   .HasForeignKey(uf => uf.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}