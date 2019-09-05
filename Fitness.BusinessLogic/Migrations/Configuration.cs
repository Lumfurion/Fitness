namespace Fitness.BusinessLogic.Migrations
{
    using System.Data.Entity.Migrations;
 

    internal sealed class Configuration : DbMigrationsConfiguration<Fitness.BusinessLogic.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Fitness.BusinessLogic.Controller.FitnessContext";
        }

        protected override void Seed(Fitness.BusinessLogic.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
