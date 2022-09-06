using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.View
{
    public class ErrorView
    {

        public void ShowError(string error)
        {
            Console.WriteLine("======================================");
            Console.WriteLine(error);
            Console.WriteLine("======================================");
        }
    }
}
