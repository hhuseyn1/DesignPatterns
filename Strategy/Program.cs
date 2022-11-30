namespace Strategy;

public interface ICompression
{
    void CompressFolder(string compressedArchiveFileName);
}

public class RarCompression : ICompression
{
    public void CompressFolder(string compressedArchiveFileName)
    {
        Console.WriteLine($"Folder is compressed using Rar approach: {compressedArchiveFileName}.rar file is created");
    }
}

public class ZipCompression : ICompression
{
    public void CompressFolder(string compressedArchiveFileName)
    {
        Console.WriteLine($"Folder is compressed using Zip approach: {compressedArchiveFileName}.zip file is created");
    }
}

public class CompressionContext
{
    private ICompression Compression;

    public CompressionContext(ICompression Compression)
    {
        this.Compression = Compression;
    }
    public void SetStrategy(ICompression Compression)
    {
        this.Compression = Compression;
    }
    public void CreateArchive(string compressedArchiveFileName)
    {
        Compression.CompressFolder(compressedArchiveFileName);
    }
}

class Program
{
    static void Main()
    {
        CompressionContext ctx = new CompressionContext(new ZipCompression());//Strategy is Zip
        ctx.CreateArchive("DotNetDesignPattern");
        ctx.SetStrategy(new RarCompression());//We change our strategy to Rar
        ctx.CreateArchive("DotNetDesignPattern");
    }
}