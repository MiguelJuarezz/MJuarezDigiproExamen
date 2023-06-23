using Microsoft.EntityFrameworkCore;
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
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {


                   // var query = context.MateriaAdd(materia.Nombre, materia.Costo);
                    var query = context.Database.ExecuteSqlRaw($"MateriaAdd '{materia.Nombre}' , {materia.Costo}");


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
            }
            return result;
        }

        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    //var query = context.MateriaDelete(IdMateria);
                    var query = context.Database.ExecuteSqlRaw($"MateriaDelete {IdMateria}");
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
            }

            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    //var updateResult = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);
                    var updateResult = context.Database.ExecuteSqlRaw($"MateriaUpdate {materia.IdMateria}, '{materia.Nombre}', {materia.Costo}");
                    if (updateResult >= 1)
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
            }

            return result;
        }

        public static ML.Result GetAll(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {
                    //libro.Rol.IdRol = (libro.Rol.IdRol == null) ? 0 : libro.Rol.IdRol;
                    //libro.Nombre = (libro.Nombre == null) ? "" : libro.Nombre;
                    //libro.ApellidoPaterno = (libro.ApellidoPaterno == null) ? "" : libro.ApellidoPaterno;

                    //var materias = context.MateriaGetAll().ToList();
                    var materias = context.Materia.FromSqlRaw("MateriaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.Materia materiaobj = new ML.Materia();
                            materiaobj.IdMateria = obj.IdMateria;
                            materiaobj.Nombre = obj.Nombre;
                            materiaobj.Costo = obj.Costo.Value;

                            result.Objects.Add(materiaobj);
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

            }

            return result;
        }

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    //var objMateria = context.MateriaGetById(idMateria).FirstOrDefault();
                    var objMateria = context.Materia.FromSqlRaw($"MateriaGetById {idMateria}").AsEnumerable().FirstOrDefault();


                    result.Objects = new List<object>();

                    if (objMateria != null)
                    {

                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = objMateria.IdMateria;
                        materia.Nombre = objMateria.Nombre;
                        materia.Costo = objMateria.Costo.Value;


                        result.Object = materia;


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
