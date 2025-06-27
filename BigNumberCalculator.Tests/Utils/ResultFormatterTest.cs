using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Utils;

namespace BigNumberCalculator.Tests.Utils;

public class ResultFormatterTest
{
    [Fact]
    public void FormatResult_WithElapsedTimeAboveOneMicrosecond_ShouldUseMilliseconds()
    {
        var num1 = "123";
        var num2 = "456";
        var result = "579";
        var operation = Operation.Add;
        var elapsed = TimeSpan.FromMilliseconds(1.5);

        var output = ResultFormatter.FormatResult(num1, num2, result, operation, elapsed);

        Assert.Contains("Operação: Soma", output);
        Assert.Contains("Operando 1: 123", output);
        Assert.Contains("Operando 2: 456", output);
        Assert.Contains("Resultado:  579", output);
        Assert.Contains("1500", output);
        Assert.Contains("ms", output);
    }

    [Fact]
    public void FormatResult_WithElapsedTimeBelowOneMicrosecond_ShouldUseMicroseconds()
    {
        var num1 = "1";
        var num2 = "1";
        var result = "2";
        var operation = Operation.Add;
        var elapsed = TimeSpan.FromMicroseconds(0.2);
        
        var output = ResultFormatter.FormatResult(num1, num2, result, operation, elapsed);
        
        Assert.Contains("Operação: Soma", output);
        Assert.Contains("Operando 1: 1", output);
        Assert.Contains("Operando 2: 1", output);
        Assert.Contains("Resultado:  2", output);
        Assert.Contains("0.2", output);
        Assert.Contains("μs", output);
    }
}