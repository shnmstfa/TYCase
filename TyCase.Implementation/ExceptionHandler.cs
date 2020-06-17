using System;
using System.Collections.Generic;
using System.Text;

namespace TyCase.Implementation
{
    public static class ExceptionHandler
    {
        public static void GlobalHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Error : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }
    }
}
