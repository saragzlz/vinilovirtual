using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class ComentarioComController : BasicController
    {
        // GET: ArtistaController/Create
        public ActionResult Create(int id)
        {
            ComentarioComViewModel com = new ComentarioComViewModel();
            com.Id = id;
            return View(com);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioComViewModel com)
        {
            try
            {
                ComentarioComRepository comRepo = new ComentarioComRepository();
                ComentarioComCEN comCEN = new ComentarioComCEN(comRepo);
                DateTime fecha = new DateTime();
                comCEN.New_("alvaro@gmail.com", com.Id, com.Texto, fecha);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}