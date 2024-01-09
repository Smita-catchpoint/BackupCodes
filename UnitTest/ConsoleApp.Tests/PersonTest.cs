using UnitTest;
using Xunit;

namespace ConsoleApp.Tests
{
    public class PersonTest
    {
        [Fact]
        public void Person_GetFullName_ReturnString()
        {
            //Arrange
            var person = new Person
            {
                FirstName = "Smita",
                LastName = "Shastri"
            };

            //Act
            string fullName = person.GetFullName();

            //Assert
            Assert.Equal("Smita Shastri", fullName);

        }

        [Theory]
        [InlineData(17,false)]
        [InlineData(18,true)]
        [InlineData(25,true)]
        public void Person_IsAdult_ReturnCorrectResult(int age , bool expectedResult)
        {
            //Arrange
            var person = new Person();

            //Act
            bool isAdult =person.IsAdult(age);

            //Assert
            Assert.Equal(expectedResult, isAdult);


        }
    }
}
