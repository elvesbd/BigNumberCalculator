namespace BigNumberCalculator.Core.Utils;

public interface IConsoleWrapper
{
    void WriteLine(string value);
    void Write(string value);
    void Clear();
    string? ReadLine();
    ConsoleKeyInfo ReadKey(bool intercept);
}