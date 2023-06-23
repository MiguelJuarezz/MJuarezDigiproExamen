using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        //[EnableCors("API")]
        [Route("GetAll")]
        [HttpGet/*("GetAll")*/]
        public IActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost("GetAll")]
        //public IActionResult GetAll(string? nombre, string? ap, string? am)
        //{

        //    ML.Usuario usuario = new ML.Usuario();

        //    //alumno.Nombre = nombre;
        //    usuario.Nombre = (nombre == null) ? "" : nombre;
        //    usuario.ApellidoPaterno = (ap == null) ? "" : ap;
        //    usuario.ApellidoMaterno = (am == null) ? "" : am;

        //    usuario.Rol = new ML.Rol();
        //    ML.Result result = BL.Usuario.GetAll(usuario);

        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}.

        // GET api/<UsuarioController>/5
        [HttpGet("GetById/{IdAlumno}")]
        public IActionResult GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        // POST api/<UsuarioController>
        [HttpPost("Add")]
        public IActionResult Post([FromBody] ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("Update")]
        public IActionResult Put([FromBody] ML.Alumno alumno)
        {
            if (alumno.IdAlumno > 0)
            {
                ML.Result result = BL.Alumno.Update(alumno);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest("Especifica el identificador");
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("Delete/{IdAlumno}")]
        public IActionResult Delete(int IdAlumno)
        {

            ML.Result result = BL.Alumno.Delete(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
