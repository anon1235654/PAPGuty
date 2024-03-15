using AdminClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class AlgorythmTest
    {
        
            [TestMethod]
            public void AverageCalc_WithValidInput_ReturnsCorrectAverage()
            {
                // Arrange
                List<int> ratingsPerBike = new List<int>
            {
                { 5 },
                { 4 },
                { 3 },
                { 2 },
                { 1 }
            };

                // Act
                //int result = Algorythm.AverageCalc(ratingsPerBike);

                // Assert
               // Assert.AreEqual(3, result); // (5 + 4 + 3 + 2 + 1) / 5 = 3
            }

            [TestMethod]
            public void AverageCalc_WithEmptyInput_ReturnsZero()
            {
                // Arrange
                List<int> ratingsPerBike = new List<int>();

                // Act
                //int result = Algorythm.AverageCalc(ratingsPerBike);

                // Assert
                //Assert.AreEqual(0, result);
            }

            
        
    }
}
