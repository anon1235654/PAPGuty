using AdminClasses;
using EntityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnitTesting.MockDBTesting;
using UnitTesting.MockDBTestingAlgo;

namespace UnitTesting.MockDBTestingAlgorythm
{
    [TestClass]
    public class AlgorythmTest
    {

        [TestMethod]
        public void AverageCalc_WithValidInput_ReturnsCorrectAverage()
        {
            var databaseContext = new InMemoryMockDBAlgo();
            var algoService = new AlgoTestManager(databaseContext);
            // Arrange
            Rating rating1 = new Rating(5, 1, 1);
            Rating rating2 = new Rating(4, 2, 1);
            Rating rating3 = new Rating(3, 3, 1);

            Bike bike1 = new Bike("CBR", "Honda", "test", 2000);
            
            User user1 = new User("john@email.com", "John Doe", "password", false);
            User user2 = new User("jane@email.com", "Jane Doe", "password", false);
            User user3 = new User("joe@email.com", "Joe Doe", "password", false);

            algoService.CreateRating(rating1);
            algoService.CreateRating(rating2);
            algoService.CreateRating(rating3);

            algoService.CreateBike(bike1);

            algoService.CreateUser(user1);
            algoService.CreateUser(user2);
            algoService.CreateUser(user3);

            // Act
            var result = algoService.AverageCalc(algoService.GetRatingList());

            // Assert
            Assert.AreEqual(2, result); // ((5 * 0.5) + (4 * 0.5) + (3 * 0.5)) / 3 = 2
        }

       [TestMethod]
        public void AverageCalc_WithValidInput_AllPremium()
        {
            var databaseContext = new InMemoryMockDBAlgo();
            var algoService = new AlgoTestManager(databaseContext);
            // Arrange
            Rating rating1 = new Rating(5, 1, 1);
            Rating rating2 = new Rating(4, 2, 1);
            Rating rating3 = new Rating(3, 3, 1);

            Bike bike1 = new Bike("CBR", "Honda", "test", 2000);

            User user1 = new User("john@email.com", "John Doe", "password", true);
            User user2 = new User("jane@email.com", "Jane Doe", "password", true);
            User user3 = new User("joe@email.com", "Joe Doe", "password", true);

            algoService.CreateRating(rating1);
            algoService.CreateRating(rating2);
            algoService.CreateRating(rating3);

            algoService.CreateBike(bike1);

            algoService.CreateUser(user1);
            algoService.CreateUser(user2);
            algoService.CreateUser(user3);

            // Act
            var result = algoService.AverageCalc(algoService.GetRatingList());

            // Assert
            Assert.AreEqual(8, result); // ((5 * 2) + (4 * 2) + (3 * 2)) / 3 = 8
        }
        [TestMethod]
        public void AverageCalc_WithValidInput_DiversifiedPremiums()
        {
            var databaseContext = new InMemoryMockDBAlgo();
            var algoService = new AlgoTestManager(databaseContext);
            // Arrange
            Rating rating1 = new Rating(5, 1, 1);
            Rating rating2 = new Rating(4, 2, 1);
            Rating rating3 = new Rating(3, 3, 1);

            Bike bike1 = new Bike("CBR", "Honda", "test", 2000);

            User user1 = new User("john@email.com", "John Doe", "password", true);
            User user2 = new User("jane@email.com", "Jane Doe", "password", false);
            User user3 = new User("joe@email.com", "Joe Doe", "password", true);

            algoService.CreateRating(rating1);
            algoService.CreateRating(rating2);
            algoService.CreateRating(rating3);

            algoService.CreateBike(bike1);

            algoService.CreateUser(user1);
            algoService.CreateUser(user2);
            algoService.CreateUser(user3);

            // Act
            var result = algoService.AverageCalc(algoService.GetRatingList());

            // Assert
            Assert.AreEqual(6, result); // ((5 * 2) + (4 * 0.5) + (3 * 2)) / 3 = 6
        }


    }
}
