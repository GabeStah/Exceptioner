using System;

namespace Exceptioner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Reflector reflector = new Exceptioner.Reflector();
        }
    }
}
