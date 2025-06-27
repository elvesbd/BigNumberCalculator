using System.Diagnostics;
using BigNumberCalculator.Core.IO;
using BigNumberCalculator.Core.Utils;
using BigNumberCalculator.Core.Enums;
using BigNumberCalculator.Core.Models;

namespace BigNumberCalculator.Core.Services
{
    public class CalculatorService(IFileManager fileManager, string number1Path, string number2Path) : ICalculatorService
    {
        private const string OutputPath = "Output/resultado.txt";

        public void Calculate(Operation operation)
        {
            try
            {
                var (num1, num2) = LoadNumbers();
                var (result, elapsed) = ExecuteOperation(num1, num2, operation);
                SaveAndShowResult(num1, num2, result, operation, elapsed);
            }
            catch (Exception ex)
            {
                FileExceptionHandler.Handle(ex);
            }
        }

        private (BigNumber, BigNumber) LoadNumbers()
        {
            var input1 = fileManager.Read(number1Path);
            var input2 = fileManager.Read(number2Path);
            return (new BigNumber(input1), new BigNumber(input2));
        }

        private (BigNumber result, TimeSpan elapsed) ExecuteOperation(BigNumber num1, BigNumber num2, Operation operation)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = operation switch
            {
                Operation.Add => num1.Add(num2),
                _ => throw new ArgumentException("Operação não suportada")
            };
            stopwatch.Stop();
            return (result, stopwatch.Elapsed);
        }

        private void SaveAndShowResult(BigNumber num1, BigNumber num2, BigNumber result, Operation operation, TimeSpan elapsed)
        {
            var output = ResultFormatter.FormatResult(num1.ToString(), num2.ToString(), result.ToString(), operation, elapsed);
            fileManager.Write(OutputPath, output);
            Console.WriteLine($"{OperationHelper.GetOperationName(operation)} realizada com sucesso!");
        }
    }
}