namespace StockShowTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        int input1 = 7, input2 = 2;
        int expected = 9;
        //Act
        int result = MyPlus(input1, input2);
        //Assert
        Assert.Equal(expected, result);
    }

    public int MyPlus(int a, int b)
    {
        return a + b;
    }
}