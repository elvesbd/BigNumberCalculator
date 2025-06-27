using BigNumberCalculator.Core.IO;
using BigNumberCalculator.Core.App;
using BigNumberCalculator.Core.Utils;
using BigNumberCalculator.Core.Services;


var consoleWrapper = new ConsoleWrapper();
var menuService = new MenuService(consoleWrapper);
var fileManager = new FileManager();
var number1Path = Path.Combine(AppContext.BaseDirectory, "Input", "numero1.txt");
var number2Path = Path.Combine(AppContext.BaseDirectory, "Input", "numero2.txt");
var calculatorService = new CalculatorService(fileManager, number1Path, number2Path);

var app = new ApplicationRunner(calculatorService, menuService, consoleWrapper);
app.Run();