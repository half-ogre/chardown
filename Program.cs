using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharDown
{
    using System.IO;
    using fn = Functions;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: chardown.exe {source} {destination}");
                Environment.Exit(1);
            }
            
            var source = args[0];
            var destination = args[1];

            var sourceFileInfo = new FileInfo(source);
            if (sourceFileInfo.Extension.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase)
                && File.Exists(sourceFileInfo.FullName))
            {
                var character = fn.ReadPdf(source);
                fn.WriteMarkdown(character, destination);
            }
            else if (sourceFileInfo.Extension.Equals(".md", StringComparison.InvariantCultureIgnoreCase)
                || (sourceFileInfo.Extension.Equals(".markdown", StringComparison.InvariantCultureIgnoreCase))
                && File.Exists(sourceFileInfo.FullName))
            {
                var character = fn.ReadMarkdown(source);
                fn.WritePdf(character, destination);
            }
            else
            {
                Console.WriteLine("Source must be a .pdf, .md, or .markdown file.");
                Environment.Exit(2);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press ENTER to quit.");
                Console.ReadLine();
            }
        }
    }
}
