using System.Data.Entity;

namespace Data.Configuration
{
    public class CustomDatabaseInitializer :
        MigrateDatabaseToLatestVersion<DataContext, MigrationsConfiguration>
    {

    }
}
