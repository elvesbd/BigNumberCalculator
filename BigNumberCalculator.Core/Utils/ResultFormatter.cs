using BigNumberCalculator.Core.Enums;

namespace BigNumberCalculator.Core.Utils;

public static class ResultFormatter
{
    public static string FormatResult(
        string num1,
        string num2,
        string result,
        Operation operation,
        TimeSpan elapsed)
    {
        var operationName = OperationHelper.GetOperationName(operation);
        var timeDisplay = elapsed.TotalMicroseconds >= 1 
            ? $"{elapsed.TotalMicroseconds} ms"
            : $"{elapsed.TotalMicroseconds} μs";

        return $"Operação: {operationName}\n" +
               $"Operando 1: {num1}\n" +
               $"Operando 2: {num2}\n" +
               $"Resultado:  {result}\n\n" +
               $"Tempo de execução: {timeDisplay}\n" +
               $"=====================================\n";
    }
}