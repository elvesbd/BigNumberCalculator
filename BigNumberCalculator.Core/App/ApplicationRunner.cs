using BigNumberCalculator.Core.Services;
using BigNumberCalculator.Core.Utils;

namespace BigNumberCalculator.Core.App;

public class ApplicationRunner(ICalculatorService calculatorService, IMenuService menuService, IConsoleWrapper console)
{
    public void Run()
    {
        var continueExecution = true;

        while (continueExecution)
        {
            try
            {
                menuService.ShowMenu();
                var selectedOperation = menuService.GetSelectedOperation();

                if (selectedOperation == null)
                {
                    console.WriteLine("Encerrando aplicação...");
                    break;
                }

                calculatorService.Calculate(selectedOperation.Value);
                continueExecution = menuService.ContinueExecution();
            }
            catch (Exception ex)
            {
                console.WriteLine($"Erro: {ex.Message}");
                continueExecution = menuService.ContinueExecution();
            }
        }
    }
}