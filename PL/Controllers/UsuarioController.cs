using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            ML.Result result = BL.Usuario.GetByUsername(username);
            if (result.Correct)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario = (ML.Usuario)result.Object;

                if (usuario.Password == password)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "El usuario y/o la contraseña son incorrectos";
                    return PartialView("Modal");

                }
            }
            else
            {
                ViewBag.Message = "El usuario y/o la contraseña son incorrectos";
                return PartialView("Modal");
            }
        }

    }
}
