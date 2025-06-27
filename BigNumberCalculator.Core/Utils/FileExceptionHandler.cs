namespace BigNumberCalculator.Core.Utils;

public abstract class FileExceptionHandler
{
    public static void Handle(Exception ex)
    {
        var message = ex switch
        {
            OverflowException _ => "Erro: estouro numérico.",
            FileNotFoundException _ => "Erro: Arquivo de entrada não encontrado.",
            IOException _ => "Erro de leitura ou escrita em arquivo.",
            ArgumentException _ => "Erro: valor de entrada inválido.",
            OutOfMemoryException _ => "Erro: o sistema ficou sem memória durante a execução.",
            _ => "Erro inesperado ao acessar arquivos."
        };


        Console.WriteLine(message);
    }
}