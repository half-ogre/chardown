using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharDown
{
    public static partial class Functions
    {
        public static void Convert(string markdownPath, string pdfPath)
        {
            var markdownFile = new FileInfo(markdownPath);

            var sourceHasMarkdownExtension = markdownFile.Extension.Equals(".md", StringComparison.InvariantCultureIgnoreCase)
                || markdownFile.Extension.Equals(".markdown", StringComparison.InvariantCultureIgnoreCase);
            if (!sourceHasMarkdownExtension)
            {
                Console.WriteLine("Source must be an .md or .markdown file.");
                Environment.Exit(2);
            }
            
            var markdownFileExists = File.Exists(markdownFile.FullName);
            if (!markdownFileExists)
            {
                Console.WriteLine("Source file does not exist.");
                Environment.Exit(3);
            }

            var pdfFile = new FileInfo(pdfPath);

            var destinationHasPdfExtension = pdfFile.Extension.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase);
            if (!destinationHasPdfExtension)
            {
                Console.WriteLine("Destination must be a .pdf file.");
                Environment.Exit(4);
            }

            var pdfFileExists = File.Exists(pdfFile.FullName);
            if (pdfFileExists)
            {
                Console.WriteLine("Destination file already exists.");
                Environment.Exit(5);
            }

            var character = ReadMarkdown(markdownFile.FullName);
            WritePdf(character, pdfFile.FullName);
        }
    }
}
