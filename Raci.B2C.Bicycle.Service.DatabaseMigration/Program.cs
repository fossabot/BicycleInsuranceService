using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using Raci.B2C.Bicycle.Service.Migrations;

namespace Raci.B2C.Bicycle.Service.DatabaseMigration
{
    class Program
    {
        private static void Main(string[] args)
        {
            string databaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbMigrationContext"].ConnectionString;

            Console.WriteLine("Updating Database: " + databaseConnectionString);

            Configuration configuration = new Configuration()
            {
                TargetDatabase = new DbConnectionInfo(databaseConnectionString, "System.Data.SqlClient")
            };

            DbMigrator migrator = new DbMigrator(configuration);

            IEnumerable<string> pendingMigrations = migrator.GetPendingMigrations();

            foreach (string pendingMigration in pendingMigrations)
            {
                Console.WriteLine("Pending Migration: {0}", pendingMigration);
            }

            migrator.Update();
        }
    }
}
