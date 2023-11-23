using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class HomeController : BasicController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UsuarioRepository usurepo = new UsuarioRepository();
            UsuarioCEN usucen = new UsuarioCEN(usurepo);

            IEnumerable<UsuarioEN> usuCli = usucen.ReadAll(0, -1);

            return View(usuCli);
        }   

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}