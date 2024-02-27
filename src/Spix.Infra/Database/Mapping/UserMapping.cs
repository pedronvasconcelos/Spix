using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spix.Domain.Users;

namespace Spix.Infra.Database.Mapping;

public class UserMapping : IEntityTypeConfiguration<UserSpix>
{
    public void Configure(EntityTypeBuilder<UserSpix> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("user_id");

        builder.Property(x => x.UserName)
            .HasColumnName("username")
            .IsRequired()
            .HasMaxLength(50);

        builder.OwnsOne(x => x.Attributes, a =>
        {
            a.Property(p => p.FirstName).HasColumnName("first_name").HasMaxLength(50);
            a.Property(p => p.LastName).HasColumnName("last_name").HasMaxLength(50);
            a.Property(p => p.BirthDate).HasColumnName("birth_date");
            a.Property(p => p.Country).HasColumnName("country").HasMaxLength(50);
            a.Property(p => p.City).HasColumnName("city").HasMaxLength(50);

            a.Property(p => p.Language).HasColumnName("user_language");
        });


        builder.OwnsOne(user => user.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .IsRequired()
                .HasConversion(
                    v => v.ToUpper(),
                    v => v.ToLower()
                );
        });

        builder.Property(x => x.Biography)
            .HasColumnName("biography");

        builder.Property(x => x.EmailIsVerified)
            .HasColumnName("email_is_verified");

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active");

        builder.Property(x => x.Location)
            .HasColumnName("user_location");

        builder.Property(x => x.WebSite)
            .HasColumnName("website");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
                  .HasConversion(v => v.ToUniversalTime(),
          v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); ;

        builder.Property(x => x.UpdatedAt)
           .HasColumnName("updated_at")
           .HasConversion(
               v => v.HasValue ? v.Value.ToUniversalTime() : (DateTime?)null,
               v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : (DateTime?)null
           );

        builder.HasMany(x => x.Spixers)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);

        builder.HasMany(x => x.SpixerLikes)
            .WithOne(sl => sl.User)
            .HasForeignKey(sl => sl.UserId);

        


    }


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