namespace BigNumberCalculator.Core.IO;

public interface IFileManager
{
    string Read(string path);
    void Write(string path, string content);
}