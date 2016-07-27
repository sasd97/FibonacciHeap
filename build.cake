var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  DotNetCoreRestore();

  var settings = new DotNetCoreBuildSettings
  {
    Configuration = "Release",
    OutputDirectory = "./bin/",
    Framework = "netstandard1.6" 
  };
  DotNetCoreBuild("./FibonacciHeap",settings);

  var testSettings = new DotNetCoreBuildSettings
  {
    Configuration = "Release",
    OutputDirectory = "./bin/",
    Framework = "netcoreapp1.0"
  };
  DotNetCoreBuild("./FibonacciHeap.Tests",testSettings);
});

RunTarget(target);