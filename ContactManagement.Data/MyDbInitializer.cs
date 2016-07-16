using System.Data.Entity;
using System.Data.Entity.Migrations;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data
{
    internal sealed class MyDbInitializer : CreateDatabaseIfNotExists<SimpleContext>
    {
        //public Configuration()
        //{
        //    AutomaticMigrationsEnabled = true;
        //    AutomaticMigrationDataLossAllowed = true;
        //}
        protected override void Seed(SimpleContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Contacts.AddOrUpdate(
                new Contact
                {
                    Name = "A.John Doe",
                    Phone = "01888888888",
                    Email = "john.doe@email.com",

                    Company = "SELISE",
                    Title = "Front End Developer",

                    House = "15/A",
                    Street = "Road 16",
                    PObox = "",
                    City = "Dhanmondi",
                    ZipCode = "1207"
                },
                new Contact
                {
                    Name = "A.John Doe2",
                    Phone = "01888888889",
                    Email = "john.doe@email.com",

                    Company = "SELISE",
                    Title = "Front End Developer",

                    House = "15/A",
                    Street = "Road 16",
                    PObox = "",
                    City = "Dhanmondi",
                    ZipCode = "1207"
                }


                );

        }
    }
}
