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

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadKey();


        }

        public static void Update()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Por favor ingrese los datos de la materia");

            Console.WriteLine("Ingrese el id de la materia que desea actualizar");
            materia.IdMateria = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos");
            materia.Creditos = byte.Parse(Console.ReadLine());

            BL.Materia.Add(materia);




        }
    }
}
