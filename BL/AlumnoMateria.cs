using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.AlumnoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(alumno);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result AlumnoMateriaGetByIdAlumno(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaGetById(IdAlumno).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno.Value;
                            alumnoMateria.Alumno.Nombre = obj.NombreAlumno;
                            alumnoMateria.Alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumnoMateria.Alumno.ApellidoMaterno = obj.ApellidoMaterno;

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnoMateria.Materia.Nombre = obj.NombreMateria;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria);
                        }
                        

                        
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static ML.Result Delete(int IdAlumnoMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(IdAlumnoMateria);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Elimino la Materia";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAllMateria()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.MateriaGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnoMateria);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities ())
                {
                    var query = context.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);
                    {
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se ha podido realizar ";
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}