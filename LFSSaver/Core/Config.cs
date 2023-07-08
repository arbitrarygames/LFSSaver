namespace LFSSaver.Core;

public class Config
{
    public Config()
    {
        ZipFilename = ThisFolder + "LFSSaver.zip";
        
    }

    public string Regex { get; set; } = @".+_facemesh.uasset";
    public string ThisFolder { get; set; } = "D:\\Dev\\Arbitrary\\Test\\";
    public string ZipFilename { get; set; }
}