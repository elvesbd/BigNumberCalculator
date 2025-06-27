using BigNumberCalculator.Core.Utils;

namespace BigNumberCalculator.Tests.Utils;

public class FileExceptionHandlerTest
{
    [Theory]
    [InlineData(typeof(OverflowException), "Erro: estouro numérico.")]
    [InlineData(typeof(FileNotFoundException), "Erro: Arquivo de entrada não encontrado.")]
    [InlineData(typeof(IOException), "Erro de leitura ou escrita em arquivo.")]
    [InlineData(typeof(ArgumentException), "Erro: valor de entrada inválido.")]
    [InlineData(typeof(OutOfMemoryException), "Erro: o sistema ficou sem memória durante a execução.")]
    [InlineData(typeof(InvalidOperationException), "Erro inesperado ao acessar arquivos.")]
    public void Handle_ShouldWriteCorrectMessageBasedOnExceptionType(Type exceptionType, string expectedMessage)
    {
        // Arrange
        var originalOut = Console.Out;
        var output = new StringWriter();
        Console.SetOut(output);

        var exceptionInstance = (Exception)Activator.CreateInstance(exceptionType)!;

        try
        {
            // Act
            FileExceptionHandler.Handle(exceptionInstance);

            // Assert
            var result = output.ToString().Trim();
            Assert.Equal(expectedMessage, result);
        }
        finally
        {
            // Cleanup
            Console.SetOut(originalOut);
        }
    }

}