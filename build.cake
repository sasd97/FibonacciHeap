var target = Argument("target", "Default");
var outputDirectoryPath = "./bin";

Task("Default")
  .IsDependentOn("UnitTests");

Task("Clean")
  .Does(()=>
  {
    CleanDirectory(outputDirectoryPath);
  });

Task("BuildLib")
  .IsDependentOn("RestoreNuget")
  .Does(()=>
  {
    var settings = new DotNetCoreBuildSettings
    {
      Configuration = "Release",
      OutputDirectory = outputDirectoryPath,
      Framework = "netstandard1.6" 
    };
    DotNetCoreBuild("./FibonacciHeap",settings);
  });

Task("RestoreNuget")
  .IsDependentOn("Clean")
  .Does(()=>
  {
    DotNetCoreRestore();
  });

Task("UnitTests")
  .IsDependentOn("BuildLib")
  .Does(()=>
  {
    var testSettings = new DotNetCoreBuildSettings
    {
      Configuration = "Release",
      OutputDirectory = outputDirectoryPath,
      Framework = "netcoreapp1.0"
    };
    DotNetCoreBuild("./FibonacciHeap.Tests",testSettings);
  });

RunTarget(target);