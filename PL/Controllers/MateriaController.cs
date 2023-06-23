using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Form()
        {
            return View(new ML.Alumno());
        }
    }
}
