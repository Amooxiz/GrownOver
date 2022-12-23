using Duende.IdentityServer.EntityFramework.Options;
using GrownOver.Domain.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GrownOver.Infrastructure.Data
{
    public class GrownOverDbContext : ApiAuthorizationDbContext<User>
    {
        public GrownOverDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HideOut> HideOuts { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<BaseItemHideout> BaseItemHideouts { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BaseItem>().ToTable("BaseItems");
            builder.Entity<Food>().ToTable("Foods");
            builder.Entity<Weapon>().ToTable("Weapons");
            builder.Entity<Armor>().ToTable("Armors");
            builder.Entity<Material>().ToTable("Materials");

            builder.Entity<BaseItemHideout>()
                .HasKey(pg => new { pg.BaseItemId, pg.HideoutId });

            builder.Entity<BaseItemHideout>()
                .HasOne<BaseItem>(pg => pg.BaseItem)
                .WithMany(p => p.BaseItemHideouts)
                .HasForeignKey(p => p.BaseItemId);

            builder.Entity<BaseItemHideout>()
                .HasOne<HideOut>(pg => pg.HideOut)
                .WithMany(g => g.BaseItemHideouts)
                .HasForeignKey(g => g.HideoutId);

            builder.Entity<UserAchievement>()
                .HasKey(pg => new { pg.UserId, pg.AchievementId });

            builder.Entity<UserAchievement>()
                .HasOne<User>(pg => pg.User)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserAchievement>()
                .HasOne<Achievement>(pg => pg.Achievement)
                .WithMany(g => g.UserAchievements)
                .HasForeignKey(g => g.AchievementId);

            builder.Entity<Inventory>()
                .HasOne(x => x.food)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.FoodId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Inventory>()
                .HasOne(x => x.weapon)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.WeaponId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Inventory>()
                .HasOne(x => x.armor)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.ArmorId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Inventory>()
                .HasOne(x => x.material)
                .WithMany(x => x.Inventories)
                .HasForeignKey(x => x.MaterialId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
