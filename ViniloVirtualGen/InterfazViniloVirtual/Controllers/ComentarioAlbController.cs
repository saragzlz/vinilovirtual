using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class ComentarioAlbController : BasicController
    {
        // GET: ComentarioAlbController/Create
        public ActionResult Create(int id)
        {
            ComentarioAlbViewModel com = new ComentarioAlbViewModel();
            com.Id = id;
            return View(com);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioAlbViewModel com)
        {
            try
            {
                ComentarioAlbRepository comRepo = new ComentarioAlbRepository();
                ComentarioAlbCEN comCEN = new ComentarioAlbCEN(comRepo);
                DateTime fecha = DateTime.Now;
                comCEN.New_("alvaro@gmail.com", com.Id, com.Texto, fecha);

                return RedirectToAction("Details", "Album",new {id = com.Id});
            }
            catch
            {
                return View();
            }
        }

         // GET: ComentarioAlbController/Delete/5
        public ActionResult Delete(int id)
        {

            ComentarioAlbRepository comRepo = new ComentarioAlbRepository();
            ComentarioAlbCEN comCEN = new ComentarioAlbCEN(comRepo);
            comCEN.Destroy(id);

            return RedirectToAction("Index", "Album");
        }

        // POST: ComentarioAlbController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}