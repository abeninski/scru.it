using Data.Configuration;
using Data.Configuration.PageRelated;
using Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public class DataContext : DbContext, IDataContext
    {
        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        public DataContext()
            : base(nameOrConnectionString: DataContext.ConnectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserScrew> UserScrews { get; set; }


        public static string ConnectionStringName
        {
            get
            {
                return "DefaultConnection";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new ScrewConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
        }

        public override int SaveChanges()
        {
            this.UpdateAuditInfo();

            return base.SaveChanges();
        }

        private void UpdateAuditInfo()
        {
            var auditInfoEntities = this.ChangeTracker
                .Entries()
                .Where(c => c.Entity is IAuditable && (c.State == EntityState.Added) || (c.State == EntityState.Modified));

            foreach (var entry in auditInfoEntities)
            {
                IAuditable auditInfoEntity = (IAuditable)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    auditInfoEntity.CreatedOn = DateTime.Now;
                }

                auditInfoEntity.ModifiedOn = DateTime.Now;
            }
        }
    }
}
