using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Utils;

namespace BigNumberCalculator.Tests.Utils;

public class OperationHelperTest
{
    [Theory]
    [InlineData(Operation.Add, "Soma")]
    [InlineData(Operation.Subtract, "Subtração")]
    [InlineData(Operation.Multiply, "Multiplicação")]
    [InlineData(Operation.Divide, "Divisão")]
    public void GetOperationName_ShouldReturnCorrectString(Operation operation, string expected)
    {
        var result = OperationHelper.GetOperationName(operation);
        
        Assert.Equal(expected, result);       ;
    }
    
    [Fact]
    public void GetOperationName_InvalidOperation_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var invalidOperation = (Operation)999;

        // Act
        Action act = () => OperationHelper.GetOperationName(invalidOperation);

        // Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal("operation", ex.ParamName);
        Assert.Contains("Operação desconhecida", ex.Message);
    }
}