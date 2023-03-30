using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumnos" in both code and config file together.
    [ServiceContract]
    public interface IAlumnos
    {
        [OperationContract]
        ML.Result Add(ML.Alumno alumno);

        [OperationContract]
        ML.Result Update(ML.Alumno alumno);

        [OperationContract]
        ML.Result Delete(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        ML.Result GetById(int IdDepartamento);
    }
}