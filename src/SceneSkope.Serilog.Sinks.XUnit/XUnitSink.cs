using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Display;
using Xunit.Abstractions;

namespace SceneSkope.Serilog.Sinks.XUnit
{
    internal class XUnitSink : ILogEventSink
    {
        private static readonly MessageTemplateTextFormatter s_formatter = new MessageTemplateTextFormatter(
                    "[{Level}] {Message}", null);
        private static readonly MessageTemplateTextFormatter s_exceptionFormatter = new MessageTemplateTextFormatter(
                    "[{Level}] {Message}{NewLine}{Exception}", null);

        private readonly ITestOutputHelper _outputHelper;

        public XUnitSink(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public void Emit(LogEvent logEvent)
        {
            var writer = new StringWriter() { NewLine = "" };
            if (logEvent.Exception == null)
            {
                s_formatter.Format(logEvent, writer);
            } else
            {
                s_exceptionFormatter.Format(logEvent, writer);
            }
            _outputHelper.WriteLine(writer.ToString());
        }
    }
}