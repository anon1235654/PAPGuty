using AdminClasses;
using EntityClasses;
namespace UnitTesting
{
    [TestClass]
    public class UserCRUDTest
    {
        IUserManager _userManager = new UserManager();
        User user = new User("UnitTesting@test.com", "UnitTest", "unitTesting");
        [TestMethod]
        public void TestCreateCustomer()
        {
            bool registerResult = _userManager.RegisterUser(user);
            Assert.IsTrue(registerResult);
        }
        [TestMethod]
        public void TestCheckCustomer()
        {
            Customer checkedUser = _userManager.GetUser(user.Email);
            Assert.AreEqual(checkedUser.Name, user.Name);
            Assert.AreEqual(checkedUser.Email, user.Email);
        }
        [TestMethod]
        public void TestDeleteCustomer()
        {
            User userToDelete = _userManager.GetUser(user.Email);
            bool deleteResult = _userManager.DeleteUser(userToDelete.Id);
            Assert.IsTrue(deleteResult);
        }
        
    }
}