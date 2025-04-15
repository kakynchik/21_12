namespace TestProject1;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        int[] numbers = { 14, 21, 35, 40, 49, 50, 63, 70, 100 };
        Func<int[], int> countMultiplesOfSeven = arr => arr.Count(num => num % 7 == 0);

        // Act
        int count = countMultiplesOfSeven(numbers);

        // Assert
        Assert.AreEqual(6, count, "The count of numbers divisible by 7 is incorrect.");
    }
}