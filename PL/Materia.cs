    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Por favor ingrese los datos de la materia");
            Console.WriteLine("Ingrese el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos");
            materia.Creditos = byte.Parse(Console.ReadLine());

            BL.Materia.Add(materia);




        }
    }
}
