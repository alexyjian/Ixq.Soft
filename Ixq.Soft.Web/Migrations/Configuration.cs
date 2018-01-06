using Ixq.Soft.DataContext;

namespace Ixq.Soft.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDataContext context)
        {
            DbSeed.SeedSystemUser(context);
        }
    }
}
