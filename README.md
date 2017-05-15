# serilog.sinks.xunit
Serilog sink for XUnit testing

To use, reference the nuget package SceneSkope.Serilog.Sinks.XUnit

In your tests, create an ILogger as shown in the [LogTests.cs](tests/SceneSkope.Serilog.Sinks.XUnit.Tests/LogTests.cs) example

```
public LogTests(ITestOutputHelper output)
{
    _output = output as TestOutputHelper;
    Log = output.CreateSerilogLogger(LogEventLevel.Verbose);
}
```