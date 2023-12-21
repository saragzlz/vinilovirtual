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
        // GET: ComentarioComController/Create
        public ActionResult Create(int id)
        {
            SessionInitialize();
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

            ComunidadEN comunidadEN = comunidadCEN.GetID(id);

            bool suscrito = false;
            foreach (UsuarioEN item in comunidadEN.Usuario)
            {
                if (item.Email == user.Email)
                {
                    suscrito = true;
                    break;
                }
            }

            int idCopy = id;
            if (!suscrito)
            {
                return RedirectToAction("Details", "Comunidad", new { id = idCopy });
            }

            ComentarioComViewModel com = new ComentarioComViewModel();
            com.Id = id;
            SessionClose();
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
                DateTime fecha = DateTime.Now;
                UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                comCEN.New_(user.Email, com.Id, com.Texto, fecha);

                return RedirectToAction("Details", "Comunidad", new { id = com.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: ComentarioComController/Delete/5
        public ActionResult Delete(int id)
        {

            ComentarioComRepository comRepo = new ComentarioComRepository();
            ComentarioComCEN comCEN = new ComentarioComCEN(comRepo);
            comCEN.Destroy(id);

            return RedirectToAction("Index", "Comunidad");
        }

        // POST: ComentarioComController/Delete/5
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