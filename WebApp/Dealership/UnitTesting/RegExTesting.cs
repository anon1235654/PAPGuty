using AdminClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class RegExTesting
    {
        [TestMethod]
        public void CheckCredentials_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string validEmail = "test@example.com";
            string validPassword = "Abc12345";

            // Act
            bool result = RegularExpressions.CheckCredentials(validEmail, validPassword);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckCredentials_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            string invalidEmail = "invalidemail";

            // Act
            bool result = RegularExpressions.CheckCredentials(invalidEmail, "Abc12345");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCredentials_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string invalidPassword = "short";

            // Act
            bool result = RegularExpressions.CheckCredentials("test@example.com", invalidPassword);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCredentials_NullEmail_ReturnsFalse()
        {
            // Act
            bool result = RegularExpressions.CheckCredentials(null, "Abc12345");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCredentials_NullPassword_ReturnsFalse()
        {
            // Act
            bool result = RegularExpressions.CheckCredentials("test@example.com", null);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
