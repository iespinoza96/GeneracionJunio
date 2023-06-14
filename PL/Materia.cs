    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
       // 5 métodos
        public  static void Add()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Por favor ingrese los datos de la materia");
            Console.WriteLine("Ingrese el nombre");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese los creditos");
            materia.Semestre = new ML.Semestre(); 
            materia.Semestre.IdSemestre = byte.Parse(Console.ReadLine());



            //ML.Result result = BL.Materia.Add(materia); //query
            //ML.Result result = BL.Materia.AddSP(materia); //SP
            ML.Result result = BL.Materia.AddEF(materia); //EF

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

        public static void GetAll()
        {
            ML.Result result = BL.Materia.GetAllSP();

            if (result.Correct)
            {
                Console.WriteLine(result.Objects);

                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("El id de la materia es: " + materia.IdMateria);
                    Console.WriteLine("El nombre de la materia es: " + materia.Nombre);
                    Console.WriteLine("El creditos de la materia es: " + materia.Creditos);
                    Console.WriteLine("------------------------------------------------------");

                }

            }
            else 
            { 

            }
        }

        public static void GetById()
        {

            Console.WriteLine("Ingrese el id de la materia que desea consultar");
             int idMateria = int.Parse(Console.ReadLine());
            ML.Result result = BL.Materia.GetByIdSP(idMateria);

            if (result.Correct)
            {
                //unboxing 
                ML.Materia materia = new ML.Materia();
                materia = (ML.Materia)result.Object;

                Console.WriteLine("El id de la materia es: " + materia.IdMateria);
                Console.WriteLine("El nombre de la materia es: " + materia.Nombre);
                Console.WriteLine("El creditos de la materia es: " + materia.Creditos);
                Console.WriteLine("------------------------------------------------------");

            }
            else
            {

            }
        }
    }
}
