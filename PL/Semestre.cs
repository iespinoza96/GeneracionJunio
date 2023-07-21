using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Semestre
    {
        public static void Add()
        {
            System.Console.WriteLine("Ingrese el nombre del semestre");
            string nombre = System.Console.ReadLine();

            ServiceSemestre.SemestreClient client = new ServiceSemestre.SemestreClient();

            var result = client.Add(nombre); //servicio
            //ML.Result result = BL.Semestre.Add(nombre); //directo al BL

            if (result.Correct)
            {
                Console.WriteLine("Se inserto el registro correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar el registro");
            }
            Console.ReadKey();

        }
    }
}
