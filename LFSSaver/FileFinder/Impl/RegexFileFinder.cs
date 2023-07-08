using System.Text.RegularExpressions;
using LFSSaver.Core;

namespace LFSSaver.FileFinder.Impl
{
  public class RegexFileFinder : IFileFinder
  {
    private Config Config { get; }

    public RegexFileFinder(Config config)
    {
        Config = config;
    }
    public List<string> FindFiles()
    {
      string folder = Config.ThisFolder;
      string regex = Config.Regex;
      return BFS(folder, regex);
    }

    /// <summary>
    /// Breadth first search for files matching the regex.
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="regex"></param>
    /// <returns></returns>
    private List<string> BFS(string folder, string regex)
    {
      var files = new List<string>();
      files.AddRange(GetMatchingFilesInDir(folder, regex));

      try
      {
        foreach (string d in Directory.GetDirectories(folder))
        {
          files.AddRange(BFS(d, regex));
        }
      }
      catch (Exception excpt)
      {
        Console.WriteLine(excpt.Message);
      }

      return files;
    }

    private List<string> GetMatchingFilesInDir(string dir, string regex)
    {
      var files = new List<string>();
      foreach (string f in Directory.GetFiles(dir))
      {
        if (Regex.IsMatch(f.ToLower(), regex))
        {
          files.Add(f);
        }
      }

      return files;
    }
  }
}
