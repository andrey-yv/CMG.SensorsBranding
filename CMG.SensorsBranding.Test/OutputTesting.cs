using System;
using System.IO;
using System.Reflection;

namespace CMG.SensorsBranding.Test
{
    class OutputTesting
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing CMG.SensorsBranding library...\n");

            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] filePaths = Directory.GetFiles(path, "Log*", SearchOption.AllDirectories);
            string[] lines = File.ReadAllLines(filePaths[0]);

            var contentOutput = SensorBranding.EvaluateLogFile(lines);

            Console.WriteLine(contentOutput);

            Console.ReadLine();
        }
    }
}
