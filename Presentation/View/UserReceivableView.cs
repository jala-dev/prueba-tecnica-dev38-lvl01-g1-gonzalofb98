using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.View
{
    public class UserReceivableView
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

        public void ShowResult(int codeMember,int totalCube, double amount)
        {            
            Console.WriteLine($"El consumo del socio {codeMember} es de  {totalCube} cubos. La deuda actual es de {amount} Bs");
            Console.WriteLine("======================================");
        }
    }
}
