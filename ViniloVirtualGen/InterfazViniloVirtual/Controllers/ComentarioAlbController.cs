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
            UsuarioViewModel user =  HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if(user == null) 
            {
                return RedirectToAction("Login", "Usuario");
            }
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
                UsuarioViewModel user =  HttpContext.Session.Get<UsuarioViewModel>("usuario");
                comCEN.New_(user.Email, com.Id, com.Texto, fecha);

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
            UsuarioViewModel user =  HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if(user == null || user.Tipo == "C") 
            {
                return RedirectToAction("Unathorize", "Usuario");
            }
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