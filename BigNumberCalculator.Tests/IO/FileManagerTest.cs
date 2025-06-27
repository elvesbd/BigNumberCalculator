using BigNumberCalculator.Core.IO;

namespace BigNumberCalculator.Tests.IO;

public class FileManagerTest
{
    [Fact]
    public void Write_ShouldCreateFileWithExpectedContent()
    {
        var fileManager = new FileManager();
        var testPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        var expectedContent = "123456789";
        
        fileManager.Write(testPath, expectedContent);

        var actual = File.ReadAllText(testPath);
        Assert.Equal(expectedContent, actual);
        File.Delete(testPath);
    }

    [Fact]
    public void Read_ShouldReturnExpectedContent()
    {
        var fileManager = new FileManager();
        var testPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        File.WriteAllText(testPath,"\n  123456789  \n");
        
        var actual = fileManager.Read(testPath);
        
        Assert.Equal("123456789", actual);
        File.Delete(testPath);;
    }
    
}