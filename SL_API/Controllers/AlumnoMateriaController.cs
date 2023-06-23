using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoMateriaController : ControllerBase
    {
        // GET api/<UsuarioController>/5
        [HttpGet("MateriaGetAsignada/{IdAlumno}")]
        public IActionResult MateriaGetAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriaGetAsignada(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }


        }

        // GET api/<UsuarioController>/5
        [HttpGet("MateriaGetNoAsignada/{IdAlumno}")]
        public IActionResult MateriaGetNoAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriaGetNoAsignada(IdAlumno);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Add/{idAlumno}/{idMateria}")]
        public IActionResult Add(int idAlumno, int idMateria)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();

            alumnoMateria.Alumno.IdAlumno = idAlumno;
            alumnoMateria.Materia.IdMateria = idMateria;

            ML.Result result = BL.AlumnoMateria.Add(alumnoMateria);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete/{idAlumno}/{idMateria}")]
        //GET api/asignatura/5
        public IActionResult Delete(int IdMateria, int IdAlumno)
        {

            ML.Result result = BL.AlumnoMateria.Delete(IdMateria, IdAlumno);

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
