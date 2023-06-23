using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AlumnoAdd '{alumno.Nombre}' , '{alumno.ApellidoPaterno}','{alumno.ApellidoMaterno}'");


                    if (query >= 1)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdAlumno)
        {

            ML.Result result = new ML.Result();
            try
            {

                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AlumnoDelete {IdAlumno}");



                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se eliminó el registro";
                    }

                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            //instancia de result
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AlumnoUpdate {alumno.IdAlumno}, '{alumno.Nombre}', '{alumno.ApellidoPaterno}' , '{alumno.ApellidoMaterno}'");
                    //almacenar y ejecutar querys de sql


                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var alumnos = context.Alumnos.FromSqlRaw("AlumnoGetAll").ToList();
                    result.Objects = new List<object>();

                    if (alumnos != null)
                    {
                        foreach (var obj in alumnos)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var objAlumno = context.Alumnos.FromSqlRaw($"AlumnoGetById {IdAlumno}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if (objAlumno != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = objAlumno.IdAlumno;
                        alumno.Nombre = objAlumno.Nombre;
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;

                        result.Object = alumno;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla alumnos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}
