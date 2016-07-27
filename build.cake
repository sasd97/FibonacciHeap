var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  DotNetCoreRestore();

  var settings = new DotNetCoreBuildSettings
  {
    Configuration = "Release",
    OutputDirectory = "./bin/"
  };
  DotNetCoreBuild("./FibonacciHeap",settings);
});

RunTarget(target);