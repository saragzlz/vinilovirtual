using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class UsuarioController : BasicController 
    {

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(loginUsuarioViewModel login)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.Email, login.Pass)==null)
            {
                ModelState.AddModelError("", "Tu email o tu password son incorrectos");
            }
            else
            {
                UsuarioEN usuEN = usuCEN.GetID(login.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                return RedirectToAction("Index", "Album");
            }
            return View();
        }

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
                usuCEN.New_(usuario.Nombre, usuario.Pass, usuario.Email, usuario.FechaNacimiento, usuario.Genero, usuario.Estado, 
                    usuario.Imagen, usuario.Apellido, usuario.Tipo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(string id)
        {
            SessionInitialize();
            UsuarioRepository usuRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            UsuarioEN usuEN = usuCEN.GetID(id);
            UsuarioViewModel usuView = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

            SessionClose();
            return View(usuView);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, UsuarioViewModel usu)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
                usuCEN.Modify(id, usu.Nombre, usu.Pass, usu.FechaNacimiento, usu.Genero, usu.Estado, usu.Imagen, usu.Apellido, usu.Tipo);

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