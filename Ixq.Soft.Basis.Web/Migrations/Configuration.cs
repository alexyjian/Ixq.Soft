using Ixq.Soft.Basis.DataContext;

namespace Ixq.Soft.Basis.Web.Migrations
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
            //DbSeed.SeedSystemUser(context);
        }
    }
}
