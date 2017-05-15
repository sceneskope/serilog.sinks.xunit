using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Display;
using Xunit.Abstractions;

namespace SceneSkope.Serilog.Sinks.XUnit
{
    public static class XUnitLoggerConfigurationExtensions
    {

        public static LoggerConfiguration XUnit(this LoggerSinkConfiguration sinkConfiguration,
            ITestOutputHelper outputHelper,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum) =>
            sinkConfiguration.Sink(new XUnitSink(outputHelper), restrictedToMinimumLevel);

        public static LoggerConfiguration CreateSerilogLoggerConfiguration(this ITestOutputHelper output, LogEventLevel level = LogEventLevel.Verbose) =>
            new LoggerConfiguration()
                .MinimumLevel.Is(level)
                .WriteTo.XUnit(output, level);

        public static ILogger CreateSerilogLogger(this ITestOutputHelper output, LogEventLevel level) =>
            CreateSerilogLoggerConfiguration(output, level)
            .CreateLogger();

    }
}
