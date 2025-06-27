using NSubstitute;
using BigNumberCalculator.Core.App;
using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Services;
using BigNumberCalculator.Core.Utils;
using NSubstitute.ExceptionExtensions;

namespace BigNumberCalculator.Tests.App;

public class ApplicationRunnerTest
{
    private readonly ICalculatorService _calculatorService;
    private readonly IMenuService _menuService;
    private readonly IConsoleWrapper _console;
    private readonly StringWriter _output;

    public ApplicationRunnerTest()
    {
        _calculatorService = Substitute.For<ICalculatorService>();
        _menuService = Substitute.For<IMenuService>();
        _console = Substitute.For<IConsoleWrapper>();
        _output = new StringWriter();

        _console.When(x => x.WriteLine(Arg.Any<string>()))
                .Do(ci => _output.WriteLine(ci.Arg<string>()));
    }

    [Fact]
    public void Run_WhenOperationIsNull_ShouldPrintExitMessage()
    {
        _menuService.GetSelectedOperation().Returns((Operation?)null);

        var runner = new ApplicationRunner(_calculatorService, _menuService, _console);
        runner.Run();

        var result = _output.ToString();
        Assert.Contains("Encerrando aplicação", result);
        _calculatorService.DidNotReceive().Calculate(Arg.Any<Operation>());
    }

    [Fact]
    public void Run_WhenValidOperationAndUserExits_ShouldCallCalculateAndExit()
    {
        _menuService.GetSelectedOperation().Returns(Operation.Add);
        _menuService.ContinueExecution().Returns(false);

        var runner = new ApplicationRunner(_calculatorService, _menuService, _console);
        runner.Run();

        _calculatorService.Received(1).Calculate(Operation.Add);
        Assert.DoesNotContain("Encerrando aplicação", _output.ToString());
    }

    [Fact]
    public void Run_WhenUserContinues_ShouldLoopAndCallCalculateTwice()
    {
        _menuService.GetSelectedOperation()
            .Returns(Operation.Add, Operation.Subtract, null);
        _menuService.ContinueExecution()
            .Returns(true, false);

        var runner = new ApplicationRunner(_calculatorService, _menuService, _console);
        runner.Run();

        _calculatorService.Received(1).Calculate(Operation.Add);
        _calculatorService.Received(1).Calculate(Operation.Subtract);
    }

    [Fact]
    public void Run_WhenGetSelectedOperationThrows_ShouldPrintErrorAndContinue()
    {
        _menuService.When(x => x.ShowMenu()).Do(_ => { });
        _menuService.GetSelectedOperation().Throws(new Exception("input inválido"));
        _menuService.ContinueExecution().Returns(false);

        var runner = new ApplicationRunner(_calculatorService, _menuService, _console);
        runner.Run();

        var text = _output.ToString();
        Assert.Contains("Erro: input inválido", text);
        _calculatorService.DidNotReceive().Calculate(Arg.Any<Operation>());
    }
}