using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Alumno alumno = new ML.Alumno();

            AlumnoService.AlumnosClient client = new AlumnoService.AlumnosClient();
            result = client.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                return View(alumno);
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Result result = new ML.Result();
            ML.Alumno alumno = new ML.Alumno();


            if (IdAlumno == null)
            {
                //add //Formulario vacio
                return View(alumno);
            }
            else
            {
                //getById
                AlumnoService.AlumnosClient client = new AlumnoService.AlumnosClient();
                result = client.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object; //Unboxig

                    //Update
                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la informacion del Alumno";
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (alumno.IdAlumno == 0)
            {
                //add
                AlumnoService.AlumnosClient client = new AlumnoService.AlumnosClient();
                result = client.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se completo el Registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al Insertar el Registro";
                }
                return View("Modal");
            }
            else
            {
                //Update
                AlumnoService.AlumnosClient client = new AlumnoService.AlumnosClient();
                result = client.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se Actualizo el Registro";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Actualizar el Registro";
                }
                return View("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            ML.Alumno alumno = new ML.Alumno();

            AlumnoService.AlumnosClient client = new AlumnoService.AlumnosClient();
            result = client.Delete(IdAlumno);

            if (result.Correct)
            {
                ViewBag.message = "se elimino el registro";
                return View("Modal");
            }
            else
            {
                ViewBag.message = "no se elimino el registro";
            }
            return View("Modal");
        }
    }
}