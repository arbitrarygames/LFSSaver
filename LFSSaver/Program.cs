// Copyright 2023 Arbitrary Games

using System.Diagnostics;
using LFSSaver.Core;
using LFSSaver.FileFinder;
using LFSSaver.Zipper;
using LFSSaver.Zipper.Impl;
using Ninject;

public class Program {
  public static void Main(string[] args)
  {
    var kernel = new StandardKernel();
    kernel.Load(new LFSSaverModule());
    var fileFinder = kernel.Get<IFileFinder>();
    var zipper = kernel.Get<IZipper>();
    
    Console.WriteLine("LFSSaver v0.1.0");
    Console.WriteLine("Searching for files...");
    var files = fileFinder.FindFiles();
    if (files.Count > 0)
    {
      Console.WriteLine("Zipping {0} files...", files.Count);
      zipper.ZipFiles(files);
    }
    else
    {
      Console.WriteLine("No matching files found.");
    }
  }
}