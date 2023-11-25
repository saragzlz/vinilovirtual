using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class UsuarioController : BasicController 
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            IList<UsuarioEN> listEN = usuarioCEN.ReadAll(0, -1);

            IEnumerable<UsuarioViewModel> listUsuarios = new UsuarioAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listUsuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            UsuarioEN usuEN = usuarioCEN.GetID(id);
            UsuarioViewModel usuView = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

            SessionClose();
            return View(usuView);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
                usuCEN.New_(usuario.Nombre, usuario.Pass, usuario.Email, usuario.FechaNacimiento, usuario.Genero, usuario.Estado, usuario.Imagen, usuario.Apellido);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
    
          // GET: UsuarioController/Delete/5
        public ActionResult Delete(string id)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
            usuCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: UsuarioController/Delete/5
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