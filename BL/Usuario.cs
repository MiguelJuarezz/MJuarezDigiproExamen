using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetByUsername(string username)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MjuarezDigiproExamenContext context = new DL.MjuarezDigiproExamenContext())
                {

                    var objUsuario = context.Usuarios.FromSqlRaw($"UsuarioGetByUsername {username}").AsEnumerable().FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Username = objUsuario.Username;
                        usuario.Password = objUsuario.Password;

                        result.Object = usuario;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los registros en la tabla usuarios";
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
