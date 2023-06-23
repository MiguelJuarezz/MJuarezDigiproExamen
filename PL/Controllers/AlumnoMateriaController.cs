using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllMateriaAsignada()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllMateriaNoAsignada()
        {
            return View();
        }


    }
}
