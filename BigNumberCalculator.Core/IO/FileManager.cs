namespace BigNumberCalculator.Core.IO;

public class FileManager : IFileManager
{
    public string Read(string path) => File.ReadAllText(path).Trim();
    public void Write(string path, string content) => File.WriteAllText(path, content);
}