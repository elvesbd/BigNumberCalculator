using BigNumberCalculator.Core.Enums;

namespace BigNumberCalculator.Core.Services;

public interface ICalculatorService
{
    void Calculate(Operation operation);
}