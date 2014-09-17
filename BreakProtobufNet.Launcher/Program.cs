using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BreakProtobufNet.Launcher
{
    public class Program
    {
        public static void Main()
        {
            var baseDir = Path.GetDirectoryName(new Uri(typeof(Program).Assembly.EscapedCodeBase).LocalPath) ?? ".";

            // load assembly from subdirectory
            var subdirAssembly = Assembly.Load(AssemblyName.GetAssemblyName(Path.Combine(baseDir, "Payload", "BreakProtobufNet.Payload.dll")));

            // ensure payload files are available in the base directory
            foreach (var file in GetPayloadFiles(Path.Combine(baseDir, "Payload")).Select(f => new { Source = f, Destination = new FileInfo(Path.Combine(baseDir, f.Name)) }).Where(p => !p.Destination.Exists))
            {
                file.Source.CopyTo(file.Destination.FullName);
            }
            // load payload from base directory
            Assembly.Load(subdirAssembly.FullName);

            // execute payload
            subdirAssembly.GetType("BreakProtobufNet.Payload.Program").GetMethod("Main", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
        }

        static IEnumerable<FileInfo> GetPayloadFiles(string dir)
        {
            return new[] { ".dll", ".pdb" }.Select(e => new FileInfo(Path.Combine(dir, "BreakProtobufNet.Payload" + e))).Where(f => f.Exists);
        }
    }
}
