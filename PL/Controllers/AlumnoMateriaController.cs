using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.AlumnoMateria.GetAll();
            ML.Alumno alumno = new ML.Alumno();

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
        public ActionResult AlumnoMateriaGetByIdAlumno(int IdAlumno) 
        {
            ML.Result result = BL.AlumnoMateria.AlumnoMateriaGetByIdAlumno(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            alumnoMateria.AlumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);

            return View(alumnoMateria);
        }

        [HttpGet]
        public ActionResult Delete(int IdAlumnoMateria)
        {
            ML.Result result = BL.AlumnoMateria.Delete(IdAlumnoMateria);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            if (result.Correct)
            {
                ViewBag.message = "se elimino el registro";
                return View("modal");
            }
            else
            {
                ViewBag.message = "no se elimino el registro";
            }
            return View(alumnoMateria);
        }

        // GET: AlumnoMateria
        [HttpGet]
        public ActionResult GetAllMateria(int IdAlumno)
        {

            ML.Result result = BL.AlumnoMateria.GetAllMateria();
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                alumnoMateria.AlumnoMaterias = result.Objects;
                alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);
                return View(alumnoMateria);
            }
            else
            {
                return View(alumnoMateria);
            }
        }

        [HttpPost]
        public ActionResult GetAllMateria(ML.AlumnoMateria alumnoMateria)
        {

            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateriaItem = new ML.AlumnoMateria();

                    alumnomateriaItem.Alumno = new ML.Alumno();
                    alumnomateriaItem.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnomateriaItem.Materia = new ML.Materia();
                    alumnomateriaItem.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.Add(alumnomateriaItem);

                }
                result.Correct = true;
                ViewBag.Message = "Se han Actualizado las Materias";
                ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;

            }
            else
            {
                result.Correct = false;
                ViewBag.message = "No se puede insertar las Materias";
            }
            return PartialView("Modal");
        }
    }
}