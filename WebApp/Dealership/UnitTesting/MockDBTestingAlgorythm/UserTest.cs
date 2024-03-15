using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace UnitTesting.MockDBTesting
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateUser_ValidData_ReturnsUserWithId()
        {
            // Arrange
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var newUser = new User
            {
                Name = "John Doe",
                Email = "john@example.com",
                Password = "password123",
                IsPremium = true
            };

            // Act
            var result = userService.CreateUser(newUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Id);
        }
        [TestMethod]
        public void CreateUser_EmptyEmail()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "",
                Password = "password123",
                IsPremium = false
            };

            //Act
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.AddUser(user));

            Assert.AreEqual(ex.Message, "Empty field.");
            //Assert.IsNull(result);
        }
        [TestMethod]
        public void CreateUser_EmptyPassword()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "john@example.com",
                Password = "",
                IsPremium = false
            };

            //Act
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.AddUser(user));

            Assert.AreEqual(ex.Message, "Empty field.");
            //Assert.IsNull(result);
        }

        [TestMethod]
        public void CreateUser_EmptyName()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "",
                Email = "john@example.com",
                Password = "passwordTest123345",
                IsPremium = false
            };

            //Act
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.AddUser(user));

            Assert.AreEqual(ex.Message, "Empty field.");
            //Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUser_ValidData()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "john@example.com",
                Password = "passwordTest123345",
                IsPremium = false
            };
            userService.CreateUser(user);

            //Act
            var result = userService.GetUserById(user.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void GetUserByID_NonExistentUserOrInvalidID()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            //Act
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => databaseContext.GetUserById(1));

            // Assert
            Assert.AreEqual(ex.Message, "User does not exist. (Parameter 'Inexistent User.')");
        }

        [TestMethod]
        public void GetUserByEmail_ValidData()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "examplepass21232",
                IsPremium = false
            };

            userService.CreateUser(user);
            //Act
            var result = userService.GetUserByEmail(user.Email);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);
        }

        [TestMethod]
        public void GetUserByEmail_NonExistentUserOrInvalidEmail()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            //Act
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.GetUserByEmail("inexistentEmail@example.com"));

            // Assert
            Assert.AreEqual(ex.Message, "User with that E-mail doesn't exist.");
        }

        [TestMethod]
        public void CheckUserCredentials_EmailPassword_ValidData()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "examplepass21232",
                IsPremium = false
            };
            userService.CreateUser(user);
            //Act
            var result = userService.CheckUserEmailPassword(user.Email, user.Password);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual(user.Password, result.Password);
        }
        [TestMethod]
        public void DeleteUserTest()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "examplepass21232",
                IsPremium = false
            };
            userService.CreateUser(user);

            User userToTest = userService.GetUserByEmail(user.Email);

            //Act
            var result = userService.DeleteUser(userToTest.Id);
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.GetUserByEmail(userToTest.Email));
            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(ex.Message, "User with that E-mail doesn't exist.");
        }

        [TestMethod]
        public void DeleteUserTest_Inexistent()
        {
            var databaseContext = new InMemoryMockDB();
            var userService = new UserTestManager(databaseContext);

            var user = new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Password = "examplepass21232",
                IsPremium = false
            };
            //Act
            var ex = Assert.ThrowsException<Exception>(() => databaseContext.DeleteUser(user.Id));

            //Assert
            Assert.AreEqual(ex.Message, "User not Found.");
        }
    }
}
