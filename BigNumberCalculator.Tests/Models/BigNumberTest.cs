using BigNumberCalculator.Core.Models;

namespace BigNumberCalculator.Tests.Models;

public class BigNumberTest
{
    [Fact]
    public void Constructor_ValidNumber_ShouldCreateInstance()
    {
        const string input = "12345";

        var bigNumber = new BigNumber(input);

        Assert.Equal("12345", bigNumber.ToString());
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("12a3")]
    [InlineData(null)]
    [InlineData(" ")]
    public void Constructor_InvalidNumber_ShouldThrowArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => new BigNumber(input));
    }
    
    [Fact]
    public void BigNumber_Add_SingleDigitNumbers_ShouldReturnCorrectResult()
    {
        var bigNumber1 = new BigNumber("1");
        var bigNumber2 = new BigNumber("2");
        
        var result = bigNumber1.Add(bigNumber2);
        
        Assert.Equal("3", result.ToString());
    }

    [Fact]
    public void BigNumber_Add_WithCarry_ShouldReturnCorrectSum()
    {
        var bigNumber1 = new BigNumber("999");
        var bigNumber2 = new BigNumber("1");
        
        var result = bigNumber1.Add(bigNumber2);
        
        Assert.Equal("1000", result.ToString());
    }

    [Fact]
    public void BigNumber_Add_LargeNumbers_ShouldReturnCorrectSum()
    {
        var bigNumber1 = new BigNumber("123456789");
        var bigNumber2 = new BigNumber("987654321");
        
        var result = bigNumber1.Add(bigNumber2);
        
        Assert.Equal("1111111110", result.ToString());
    }

    [Fact]
    public void BigNumber_Add_ZeroPlusNumber_ShouldReturnSameNumber()
    {
        var bigNumber1 = new BigNumber("0");
        var bigNumber2 = new BigNumber("123456789");
        
        var result = bigNumber1.Add(bigNumber2);
        
        Assert.Equal("123456789", result.ToString());
    }
    
    [Fact]
    public void BigNumber_Add_TwoZeros_ShouldReturnZero()
    {
        var bigNumber1 = new BigNumber("0");
        var bigNumber2 = new BigNumber("0");
        
        var result = bigNumber1.Add(bigNumber2);
        
        Assert.Equal("0", result.ToString());
    }
    
    [Fact]
    public void BigNumber_ToString_ShouldReturnCorrectString()
    {
        var number = new BigNumber("54321");

        var str = number.ToString();

        Assert.Equal("54321", str);
    }

}