using System;
using System.Diagnostics;

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

            fn.Convert(source, destination);
            
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press ENTER to quit.");
                Console.ReadLine();
            }
        }
    }
}
