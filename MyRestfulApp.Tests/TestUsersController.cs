using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using MyRestfulApp.Models;
using MyRestfulApp.Controllers;

namespace MyRestfulApp.Tests
{
    [TestClass]
    public class TestUsersController
    {
        [TestMethod]
        public void PostUser_ShouldReturnSameUser()
        {
            var controller = new UsersController(new TestUserContext());

            var user = GetDemoUser();

            var result =
                controller.PostUser(user) as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Nombre, user.Nombre);
        }

        [TestMethod]
        public void PutUser_ShouldReturnStatusCode()
        {
            var controller = new UsersController(new TestUserContext());

            var user = GetDemoUser();

            var result = controller.PutUser(user.Id, user) as StatusCodeResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutUser_ShouldFail_WhenDifferentID()
        {
            var controller = new UsersController(new TestUserContext());

            var badresult = controller.PutUser(999, GetDemoUser());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GetUser_ShouldReturnUserWithSameID()
        {
            var context = new TestUserContext();
            context.Users.Add(GetDemoUser());

            var controller = new UsersController(context);
            var result = controller.GetUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);
        }

        [TestMethod]
        public void GetUsers_ShouldReturnAllUsers()
        {
            var context = new TestUserContext();
            context.Users.Add(new User { Id = 1, Nombre = "Juan", Apellido = "Perez", Email = "juanperez@mail.com", Password = "1234" });
            context.Users.Add(new User { Id = 2, Nombre = "Rodrigro", Apellido = "Rodriguez", Email = "juanrodriguez@mail.com", Password = "1234" });
            context.Users.Add(new User { Id = 3, Nombre = "Julieta", Apellido = "Caram", Email = "pablocaram@mail.com", Password = "1234" });

            var controller = new UsersController(context);
            var result = controller.GetUsers() as TestUserDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        [TestMethod]
        public void DeleteUser_ShouldReturnOK()
        {
            var context = new TestUserContext();
            var item = GetDemoUser();
            context.Users.Add(item);

            var controller = new UsersController(context);
            var result = controller.DeleteUser(3) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        User GetDemoUser()
        {
            return new User() { Id = 3, Nombre = "Julieta", Apellido = "Caram", Email = "pablocaram@mail.com", Password = "1234" };
        }
    }
}