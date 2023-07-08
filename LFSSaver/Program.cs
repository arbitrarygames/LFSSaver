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


    var files = fileFinder.FindFiles();
    Console.WriteLine("Matching files: ");
    foreach (var file in files)
    {
      Console.WriteLine(file);
    }
    Console.WriteLine("Zipping files...");
    zipper.ZipFiles(files);
    Console.WriteLine("Done!");
  }
}