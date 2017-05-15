using System;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SceneSkope.Serilog.Sinks.XUnit.Tests
{
    public class LogTests
    {
        private ILogger Log { get; }
        private readonly TestOutputHelper _output;

        public LogTests(ITestOutputHelper output)
        {
            _output = output as TestOutputHelper;
            Log = output.CreateSerilogLogger(LogEventLevel.Verbose);
        }

        [Fact]
        public void TestLogGoesToOutput()
        {
            Assert.Empty(_output.Output);
            Log.Information("Simple test");
            Assert.Equal($"[Information] Simple test{Environment.NewLine}", _output.Output);
        }

        [Fact]
        public void TestLogWithExceptionGoesToOutput()
        {
            Assert.Empty(_output.Output);
            Log.Error(new Exception("Error"), "Got error");
            Assert.Equal($"[Error] Got error{Environment.NewLine}System.Exception: Error{Environment.NewLine}{Environment.NewLine}", _output.Output);

        }

    }
}
