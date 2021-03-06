#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var outputDir = "./bin";

Task("Default")
  .IsDependentOn("Xunit")
  .Does(() =>
{
});

Task("Xunit")
  .IsDependentOn("Build")
  .Does(()=>
  {
    XUnit2("./src/FibonacciHeap.Tests/bin/Release/FibonacciHeap.Tests.dll");
  });

Task("Build")
  .IsDependentOn("Nuget")
  .Does(()=>
  {
    if(IsRunningOnUnix())
    {
        XBuild("FibonacciHeap.sln",new XBuildSettings {
          Configuration = "Release"
        }.WithProperty("POSIX","True"));
    }
    else
    {
        MSBuild("FibonacciHeap.sln", new MSBuildSettings {
          Configuration = "Release"
        });
    }
  });

Task("Nuget")
  .IsDependentOn("Clean")
  .Does(()=>
  {
    NuGetRestore("./");
  });

Task("Clean")
  .Does(()=>
  {
    CleanDirectories(outputDir+"/**");
  });

RunTarget(target);