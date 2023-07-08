// Copyright 2023 Arbitrary Games

using System.Diagnostics;
using LFSSaver.Core;
using LFSSaver.FileFinder;
using Ninject;

public class Program {
  public static void Main(string[] args)
  {
    var kernel = new StandardKernel();
    kernel.Load(new LFSSaverModule());
    var fileFinder = kernel.Get<IFileFinder>();
    
    
    var files = fileFinder.FindFiles();
    Console.WriteLine("Matching files: ");
    foreach (var file in files)
    {
      Console.WriteLine(file);
    }
  }
}