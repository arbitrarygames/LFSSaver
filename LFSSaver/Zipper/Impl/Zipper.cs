using System.IO.Compression;
using System.Text;
using LFSSaver.Core;
using Newtonsoft.Json;

namespace LFSSaver.Zipper.Impl;

public class Zipper : IZipper
{
    private Config Config { get; }
    
    public Zipper(Config config)
    {
        Config = config;
    }
    public void ZipFiles(List<string> files)
    {
        Dictionary<string, string> zipEntries = new Dictionary<string, string>();
        string zipFilename = Config.ZipFilename;
        using(FileStream zipFile = File.Open(zipFilename, FileMode.Create))
        {
            using (ZipArchive zip = new ZipArchive(zipFile, ZipArchiveMode.Create))
            {
                foreach (string file in files) 
                {
                    Guid guid = Guid.NewGuid();
                    zipEntries.Add(guid.ToString(), file);
                    zip.CreateEntryFromFile(file, guid.ToString());
                }
                var json = JsonConvert.SerializeObject(zipEntries);
                var jsonFile = zip.CreateEntry("bindings.json").Open();
                jsonFile.Write(Encoding.UTF8.GetBytes(json));
                jsonFile.Close();
            }
        }
    }
}