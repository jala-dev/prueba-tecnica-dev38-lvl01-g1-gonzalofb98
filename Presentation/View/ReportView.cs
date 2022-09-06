using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.View
{
    public class ReportView
    {
        public InputData RequestData()
        {
            return this.GetData();
        }

        private InputData GetData()
        {
            InputData input = new InputData();
            Console.WriteLine("======================================");
            Console.WriteLine("1. Ingrese el codigo del socio: ");
            input.fields.Add("CodigoSocio", Console.ReadLine());
            return input;
        }

        public void ShowResult(int memberID,string fullName, double totalDebt)
        {
            Console.WriteLine($"R. El socio {fullName}, con ID: {memberID} tiene una deuda de: {totalDebt}");
            Console.WriteLine("======================================");
        }
    }
}
