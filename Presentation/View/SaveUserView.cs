using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.View
{
    public class SaveUserView
    {
        public InputData RequestData()
        {
            return this.GetData();
        }

        private InputData GetData()
        {
            InputData input = new InputData();
            Console.WriteLine("======================================");
            Console.WriteLine("A continuación ingrese los datos del nuevo socio");
            Console.WriteLine("1. Ingrese el codigo del socio nuevo: ");
            input.fields.Add("CodigoSocio", Console.ReadLine());
            Console.WriteLine("2. Ingrese el apellido: ");
            input.fields.Add("Apellido", Console.ReadLine());
            Console.WriteLine("2. Ingrese el nombre: ");
            input.fields.Add("Nombre", Console.ReadLine());
            return input;
        }
        public void ShowResult(string fullName)
        {
            Console.WriteLine($"El nuevo socio {fullName} fue agregado correctamente.");
            Console.WriteLine("======================================");
        }
    }
}
