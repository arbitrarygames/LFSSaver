using LFSSaver.FileFinder;
using LFSSaver.FileFinder.Impl;
using Ninject.Modules;
using LFSSaver.Zipper;

namespace LFSSaver.Core
{
  internal class LFSSaverModule : NinjectModule
  {
    public override void Load()
    {
      Bind<IFileFinder>().To<RegexFileFinder>().InTransientScope();
      Bind<IZipper>().To<Zipper.Impl.Zipper>().InTransientScope();
      Bind<Config>().ToSelf().InSingletonScope();
    }
  }
}
