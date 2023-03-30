using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {

                    int query = context.MateriaAdd(materia.Nombre,materia.Costo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Inserto la Materia";
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
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {

                    int query = context.MateriaUpdate(materia.IdMateria,materia.Nombre,materia.Costo);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se Modifico la Materia";
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
        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.MateriaDelete(IdMateria);
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
        public static ML.Result GetAll()
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
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre  = obj.Nombre;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);
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
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AAcostaControlEscolarEntities context = new DL.AAcostaControlEscolarEntities())
                {
                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Costo = query.Costo.Value;

                        result.Object = materia;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}