using BigNumberCalculator.Core.Enums;

namespace BigNumberCalculator.Core.Utils;

public static class OperationHelper
{
    public static string GetOperationName(Operation operation) => operation switch
    {
        Operation.Add => "Soma",
        Operation.Subtract => "Subtração",
        Operation.Multiply => "Multiplicação",
        Operation.Divide => "Divisão",
        _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, "Operação desconhecida.")
    };
}