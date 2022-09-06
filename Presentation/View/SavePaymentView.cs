using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.View
{
    public class SavePaymentView
    {
        public InputData RequestData()
        {
            return this.GetData();
        }

        private InputData GetData()
        {
            InputData input = new InputData();
            Console.WriteLine("======================================");
            Console.WriteLine("Ingrese el codigo del socio: ");
            input.fields.Add("CodigoSocio", Console.ReadLine());
            return input;
        }
        public void ShowResult(string fullName)
        {
            Console.WriteLine($"El pago del socio {fullName} se realizo correctamente.");
            Console.WriteLine("======================================");
        }
    }
}
