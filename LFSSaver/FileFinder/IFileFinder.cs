using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFSSaver.FileFinder
{
  public interface IFileFinder
  {
    
    /// <summary>
    /// Returns a list of files that should be zipped.
    /// </summary>
    /// <returns></returns>
    public List<string> FindFiles();
  }
}
