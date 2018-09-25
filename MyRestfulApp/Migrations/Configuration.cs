namespace MyRestfulApp.Migrations
{
    using MyRestfulApp.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserContext context)
        {
            //  This method will be called after migrating to the latest version.
            base.Seed(context);

            IList<User> defaultUsers = new List<User>
            {
                new User { Nombre = "Juan", Apellido = "Perez", Email = "juanperez@mail.com", Password = "1234" },
                new User { Nombre = "Rodrigro", Apellido = "Rodriguez", Email = "juanrodriguez@mail.com", Password = "1234" },
                new User { Nombre = "Julieta", Apellido = "Caram", Email = "pablocaram@mail.com", Password = "1234" },
                new User { Nombre = "Pablo", Apellido = "Gonzalez", Email = "pablogonzalez@mail.com", Password = "1234" },
                new User { Nombre = "Nicolas", Apellido = "Sorroche", Email = "nicosorroche@mail.com", Password = "1234" },
                new User { Nombre = "Lucas", Apellido = "Hyde", Email = "tomashyde@mail.com", Password = "1234" },
                new User { Nombre = "Tomas", Apellido = "Dambrosio", Email = "tomasdambrosio@mail.com", Password = "1234" }
            };
            context.Users.AddRange(defaultUsers);
            context.SaveChanges();
        }
    }
}
