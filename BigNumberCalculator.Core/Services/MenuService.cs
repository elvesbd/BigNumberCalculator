using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Utils;

namespace BigNumberCalculator.Core.Services
{
    public class MenuService(IConsoleWrapper console) : IMenuService
    {
        public void ShowMenu()
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
        }

        public Operation? GetSelectedOperation()
        {
            var input = console.ReadLine();

            return input switch
            {
                "1" => Operation.Add,
                "2" => Operation.Subtract,
                "3" => Operation.Multiply,
                "4" => Operation.Divide,
                "0" => null,
                _ => throw new ArgumentException("Opção inválida! Digite um número de 0 a 4.")
            };
        }

        public bool ContinueExecution()
        {
            console.WriteLine("");
            console.WriteLine("Pressione qualquer tecla para voltar ao menu: ");
            var key = console.ReadKey(true);
            return key.Key != ConsoleKey.Escape;
        }
    }
}