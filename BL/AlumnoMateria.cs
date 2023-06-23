using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result MateriaGetAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    //var objAlumnoMateria = context.MateriaGetAsiganadas(IdAlumno).FirstOrDefault();
                    var objAlumnoMateria = context.AlumnoMateria.FromSqlRaw($"MateriaGetAsiganadas {IdAlumno}").ToList();
                    result.Objects = new List<object>();


                    if (objAlumnoMateria != null)
                    {
                        foreach (var obj in objAlumnoMateria)
                        {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = obj.IdAlumno.Value;


                            alumnoMateria.Materia = new ML.Materia();

                            alumnoMateria.Materia.IdMateria = obj.IdMateria.Value;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo;


                            result.Objects.Add(alumnoMateria);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla";
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

        public static ML.Result MateriaGetNoAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    //var objAlumnoMateria = context.MateriaGetAsiganadas(IdAlumno).FirstOrDefault();
                    var resultado = from materia in context.Materia
                                    where !(from alumnoMateria in context.AlumnoMateria
                                            join mat in context.Materia on alumnoMateria.IdMateria equals mat.IdMateria
                                            join alumno in context.Alumnos on alumnoMateria.IdAlumno equals alumno.IdAlumno
                                            where alumno.IdAlumno == IdAlumno
                                            select mat.IdMateria).Contains(materia.IdMateria)
                                    select new
                                    {
                                        materia.IdMateria,
                                        NombreMateria = materia.Nombre,
                                        Costo = materia.Costo
                                    };
                    result.Objects = new List<object>();


                    if (resultado != null)
                    {
                        foreach (var obj in resultado)
                        {

                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();




                            alumnoMateria.Materia = new ML.Materia();

                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.NombreMateria;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;


                            result.Objects.Add(alumnoMateria);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla";
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


        public static ML.Result Add(ML.AlumnoMateria alumnomateria)
        {
            Result result = new Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"AlumnoMateriaAdd '{alumnomateria.Alumno.IdAlumno}', {alumnomateria.Materia.IdMateria}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Ex = ex;
            }
            return (result);
        }

        public static ML.Result Delete(int IdMateria, int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AlumnoMateriaDelete {IdMateria}, {IdAlumno}");
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
            catch (Exception Ex)
            {
                result.Ex = Ex;
                result.ErrorMessage = "Ocurrio un Error" + result.Ex.Message;
                throw;
            }

            return result;
        }
    }
}
