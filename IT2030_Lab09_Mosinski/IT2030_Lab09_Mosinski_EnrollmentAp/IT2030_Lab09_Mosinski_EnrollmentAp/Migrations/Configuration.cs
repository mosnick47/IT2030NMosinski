namespace IT2030_Lab09_Mosinski_EnrollmentAp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IT2030_Lab09_Mosinski_EnrollmentAp.Models.EnrollmentDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IT2030_Lab09_Mosinski_EnrollmentAp.Models.EnrollmentDB";
        }

        protected override void Seed(IT2030_Lab09_Mosinski_EnrollmentAp.Models.EnrollmentDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
