namespace LFSSaver.Core;

public class Config
{
    public Config()
    {
#if !DEBUG
            ThisFolder = AppDomain.CurrentDomain.BaseDirectory;
#else
        ThisFolder = "D:\\Dev\\Arbitrary\\Test";
#endif

        ZipFilename = ThisFolder + "LFSSaver.lfs";
    }

    public string Regex { get; set; } = @".+_facemesh.uasset";
    public string ThisFolder { get; set; }
    public string ZipFilename { get; set; }
}