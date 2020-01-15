namespace Academic.Database.Migrations
{
    using Academic.Database.Seeders;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Academic.Database.AcademicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Academic.Database.AcademicContext context)
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
            //SeedSchoolType(context);
            //SeedSchool(context);
            //context.SaveChanges();
            new GenderSeeder(context).Seed();
            new GradeSeeder(context).Seed();
            new RoleSeeder(context).Seed();
            new SchoolSeeder(context).Seed();
            new UserFileSeeder(context).Seed();
            new UserSeeder(context).Seed();

            new CourseSeeder(context).Seed();
            new ProgramSeeder(context).Seed();
            new AcademicYearSeeder(context).Seed();

        }


        //private void SeedSchoolType(Academic.Database.AcademicContext context)
        //{
        //    if (!context.SchoolType.Any())
        //    {
        //        // insert all
        //        foreach (var t in StaticValues.SchoolType)
        //        {
        //            context.SchoolType.Add(new SchoolType() { Name = t });
        //        }
        //    }
        //}

        //private void SeedSchool(Academic.Database.AcademicContext context)
        //{
        //    if (!context.SchoolType.Any())
        //    {
        //        // insert all
        //    }
        //}

    }
}
