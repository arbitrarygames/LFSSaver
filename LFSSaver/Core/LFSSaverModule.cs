using LFSSaver.FileFinder;
using LFSSaver.FileFinder.Impl;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFSSaver.Core
{
  internal class LFSSaverModule : NinjectModule
  {
    public override void Load()
    {
      Bind<IFileFinder>().To<RegexFileFinder>().InTransientScope();
      Bind<Config>().ToSelf().InSingletonScope();
    }
  }
}
