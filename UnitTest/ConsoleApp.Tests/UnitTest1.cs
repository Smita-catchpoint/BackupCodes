using UnitTest;
using Xunit;

namespace ConsoleApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Addition addition = new Addition();

            //Act
            int Result = addition.Add(2, 3);

            //Assert
            Assert.Equal(5, Result);

        }
    }
}