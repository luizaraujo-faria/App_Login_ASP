using App_Login.Libraries.Login;
using App_Login.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace App_Login.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {

        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository repository, LoginColaborador loginCliente)
        {
            _colaboradorRepository = repository;
            _loginColaborador = loginCliente;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PainelGerente()
        {
            return View();
        }
    }
}
