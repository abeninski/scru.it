using System.Data.Entity.Migrations;

namespace Data.Configuration
{
    public class MigrationsConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public MigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
