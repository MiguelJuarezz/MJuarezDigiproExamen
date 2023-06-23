using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        // GET: api/<UsuarioController>
        //[EnableCors("API")]
        [Route("api/Materia/GetAll")]
        [HttpGet/*("GetAll")*/]
        public IActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            
            ML.Result result = BL.Materia.GetAll(materia);

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
        [HttpGet("api/Materia/GetById/{IdMateria}")]
        public IActionResult GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetById(IdMateria);
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
        [HttpPost("api/Materia/Add")]
        public IActionResult Post([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);
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
        [HttpPut("api/Materia/Update")]
        public IActionResult Put([FromBody] ML.Materia materia)
        {
            if (materia.IdMateria > 0) {
                ML.Result result = BL.Materia.Update(materia);
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
        [HttpDelete("api/Materia/Delete/{IdMateria}")]
        public IActionResult Delete(int IdMateria)
        {

            ML.Result result = BL.Materia.Delete(IdMateria);
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
