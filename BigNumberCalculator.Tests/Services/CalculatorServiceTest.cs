using NSubstitute;
using BigNumberCalculator.Core.IO;
using BigNumberCalculator.Core.Enums;
using NSubstitute.ExceptionExtensions;
using BigNumberCalculator.Core.Services;

namespace BigNumberCalculator.Tests.Services;

public class CalculatorServiceTest
{
    private readonly StringWriter _consoleOutput = new();
    private readonly IFileManager _fileManager = Substitute.For<IFileManager>();
    private const string Number1Path = "Input/numero1.txt";
    private const string Number2Path = "Input/numero2.txt";
    private const string OutputPath = "Output/resultado.txt";

    [Fact]
    public void Calculate_WhenOverflowExceptionOccursOnFirstInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Throws(new OverflowException());
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: estouro numérico.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenOverflowExceptionOccursOnSecondInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Throws(new OverflowException());
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: estouro numérico.", output.Trim());
    }

    [Fact]
    public void Calculate_WhenFirstInputFileIsMissing_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Throws(new FileNotFoundException());
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: Arquivo de entrada não encontrado.", output.Trim());
    }

    [Fact]
    public void Calculate_WhenSecondInputFileIsMissing_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Throws(new FileNotFoundException());
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);;
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: Arquivo de entrada não encontrado.", output.Trim());;
    }

    [Fact]
    public void Calculate_WhenIOExceptionOccursOnFirstInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Throws(new IOException());
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro de leitura ou escrita em arquivo.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenIOExceptionOccursOnSecondInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Throws(new IOException());
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro de leitura ou escrita em arquivo.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenArgumentExceptionOccursOnFirstInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123.7");
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: valor de entrada inválido.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenArgumentExceptionOccursOnSecondInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Returns("456.7");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: valor de entrada inválido.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenOutOfMemoryExceptionOccursOnFirstInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Throws(new OutOfMemoryException());
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: o sistema ficou sem memória durante a execução.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenOutOfMemoryExceptionOccursOnSecondInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Throws(new OutOfMemoryException());
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro: o sistema ficou sem memória durante a execução.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenUnknowExceptionOccursOnFirstInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Throws(new Exception());
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro inesperado ao acessar arquivos.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenUnknowExceptionOccursOnSecondInputFile_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Throws(new Exception());
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);
        
        calculatorService.Calculate(Operation.Add);
        
        var output = _consoleOutput.ToString();
        Assert.Equal("Erro inesperado ao acessar arquivos.", output.Trim());
    }
    
    [Fact]
    public void Calculate_WhenOperationIsNotSupported_ShouldDisplayFriendlyErrorMessage()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Returns("456");

        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        Console.SetOut(_consoleOutput);

        calculatorService.Calculate(Operation.Subtract);

        var output = _consoleOutput.ToString().Trim();
        Assert.Equal("Erro: valor de entrada inválido.", output);
    }

    
    [Fact]
    public void Calculate_AddOperation_ShouldSaveCorrectResult()
    {
        _fileManager.Read(Number1Path).Returns("123");
        _fileManager.Read(Number2Path).Returns("456");
        var calculatorService = new CalculatorService(_fileManager, Number1Path, Number2Path);
        
        calculatorService.Calculate(Operation.Add);
     
        _fileManager.Received(1).Write(
            OutputPath,
            Arg.Is<string>(output => 
                output.Contains("123") && 
                output.Contains("456") && 
                output.Contains("579")
            )
        );
    }
}