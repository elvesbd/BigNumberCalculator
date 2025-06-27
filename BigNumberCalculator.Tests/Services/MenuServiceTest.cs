using NSubstitute;
using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Utils;
using BigNumberCalculator.Core.Services;

namespace BigNumberCalculator.Tests.Services;


public class MenuServiceTest
{
    [Fact]
    public void ShowMenu_ShouldWriteExpectedTextToConsole()
    {
        var console = Substitute.For<IConsoleWrapper>();
        var menuService = new MenuService(console);

        menuService.ShowMenu();

        Received.InOrder(() =>
        {
            console.Clear();
            console.WriteLine("=== CALCULADORA DE GRANDES NÚMEROS ===");
            console.WriteLine("");
            console.WriteLine("Escolha a operação:");
            console.WriteLine("1 - Soma");
            console.WriteLine("2 - Subtração");
            console.WriteLine("3 - Multiplicação");
            console.WriteLine("4 - Divisão");
            console.WriteLine("0 - Sair");
            console.WriteLine("");
            console.Write("Digite sua opção: ");
        });
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEnters1_ShouldReturnAdd()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("1");

        var service = new MenuService(console);
        var result = service.GetSelectedOperation();

        Assert.Equal(Operation.Add, result);
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEnters2_ShouldReturnSubtract()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("2");

        var service = new MenuService(console);
        var result = service.GetSelectedOperation();

        Assert.Equal(Operation.Subtract, result);
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEnters3_ShouldReturnMultiply()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("3");

        var service = new MenuService(console);
        var result = service.GetSelectedOperation();

        Assert.Equal(Operation.Multiply, result);
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEnters4_ShouldReturnDivide()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("4");

        var service = new MenuService(console);
        var result = service.GetSelectedOperation();

        Assert.Equal(Operation.Divide, result);
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEnters0_ShouldReturnNull()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("0");

        var service = new MenuService(console);
        var result = service.GetSelectedOperation();

        Assert.Null(result);
    }

    [Fact]
    public void GetSelectedOperation_WhenUserEntersInvalid_ShouldThrowArgumentException()
    {
        var console = Substitute.For<IConsoleWrapper>();
        console.ReadLine().Returns("9");

        var service = new MenuService(console);

        var ex = Assert.Throws<ArgumentException>(() => service.GetSelectedOperation());
        Assert.Equal("Opção inválida! Digite um número de 0 a 4.", ex.Message);
    }

    [Fact]
    public void ContinueExecution_WhenKeyIsEscape_ShouldReturnFalse()
    {
        var console = Substitute.For<IConsoleWrapper>();
        var escapeKey = new ConsoleKeyInfo('\0', ConsoleKey.Escape, false, false, false);
        console.ReadKey(true).Returns(escapeKey);

        var service = new MenuService(console);
        var result = service.ContinueExecution();

        Assert.False(result);
    }

    [Fact]
    public void ContinueExecution_WhenKeyIsNotEscape_ShouldReturnTrue()
    {
        var console = Substitute.For<IConsoleWrapper>();
        var anyKey = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
        console.ReadKey(true).Returns(anyKey);

        var service = new MenuService(console);
        var result = service.ContinueExecution();

        Assert.True(result);
    }
}
