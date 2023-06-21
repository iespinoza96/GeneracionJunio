using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllLINQ();
            ML.Materia materia = new ML.Materia();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                //materia.Materias = new List<object> ();
                ViewBag.Message = result.Message;
                return View(materia);
            }

        }


        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            if (idMateria == null)
            {
                //AGREGAR
                //MOSTRAR EL FORMULARIO VACIO 
                ViewBag.Titulo = "Agregar";
                
                return View();
            }
            else
            {
                //GetById(IdMateria)
                ML.Result result = BL.Materia.GetByIdEF(idMateria.Value);

                if (result.Correct)
                {
                    ML.Materia materia = (ML.Materia)result.Object; //unboxing
                    ViewBag.Titulo = "Actualizar";
                    return View(materia);
                }
                //return View(materia);


                return View();

            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0)
            {
                //AGREGAR
                ML.Result result = BL.Materia.AddLINQ(materia);

                if (result.Correct)
                {
                    ViewBag.Titulo = "Registro Exitoso";
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
                else
                {
                    ViewBag.Titulo = "ERROR";
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
                
            }
            else
            {
                //ACTUALIZAR
                //ML.Result result = BL.Materia.
                return View();

            }

        }


    }
}