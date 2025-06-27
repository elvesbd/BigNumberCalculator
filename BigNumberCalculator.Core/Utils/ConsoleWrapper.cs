using System;

namespace BigNumberCalculator.Core.Utils
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string value) => Console.WriteLine(value);
        public void Write(string value) => Console.Write(value);
        public void Clear() => Console.Clear();
        public string? ReadLine() => Console.ReadLine();
        public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);
    }
}