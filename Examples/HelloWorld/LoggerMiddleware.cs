using System;
using System.Text.RegularExpressions;

namespace Cycles.Examples
{
    public class LoggerMiddleware
    {
        public LoggerMiddleware()
        {
            Middlewares.AddListener(Log);
        }

        private void Log(DebugInfo info)
        {
            // Get the cycle name only without the namespace.
            var cycleName = info.cycleName;
            var match = Regex.Match(cycleName, @"^.*[.](.*)$");
            if (match.Success)
                cycleName = match.Groups[1].ToString();

            // Turn the data into a string.
            var data = (Data) info.data;
            var dataString = $"{{ \"name\": \"{data.name}\" }}";

            Console.WriteLine($"[{cycleName} - {info.state}] data: {dataString} - datetime: {info.dateTime}");
        }
    }
}