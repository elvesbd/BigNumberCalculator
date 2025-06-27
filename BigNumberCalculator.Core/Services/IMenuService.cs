using BigNumberCalculator.Core.Enums;

namespace BigNumberCalculator.Core.Services;

public interface IMenuService
{
    void ShowMenu();
    Operation? GetSelectedOperation();
    bool ContinueExecution();
}