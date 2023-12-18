using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class UsuarioController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public UsuarioController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user != null)
            {
                return RedirectToAction("Explorer", "Album");
            }
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(loginUsuarioViewModel login)
        {
            SessionInitialize();
            UsuarioRepository usuRepo = new UsuarioRepository(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.Email, login.Pass) == null)
            {
                ModelState.AddModelError("", "Tu email o tu password son incorrectos");
            }
            else
            {
                UsuarioEN usuEN = usuCEN.GetID(login.Email);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Explorer", "Album");
            }
            SessionClose();
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
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }


            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            UsuarioEN usuEN = usuarioCEN.GetID(id);
            UsuarioViewModel usuView = new UsuarioAssembler().ConvertirENToViewModel(usuEN);

            SessionClose();
            return View(usuView);
        }

        // GET: UsuarioController/Register
        public ActionResult Register()
        {

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user != null)
            {
                return RedirectToAction("Explorer", "Album");
            }

            return View();
        }

        // POST: UusarioController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(registroUsuarioViewModel usu)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);


                string fileName = "", path = "";
                if (usu.Fichero != null && usu.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(usu.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await usu.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    usuCEN.New_(usu.Nombre, usu.Pass, usu.Email, usu.FechaNacimiento, usu.Genero, 
                        ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal,
                    fileName, usu.Apellido, ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);
                }
                return RedirectToAction("Explorer", "Album");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: UusarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsuarioViewModel usu)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);


                string fileName = "", path = "";
                if (usu.Fichero != null && usu.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(usu.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await usu.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    usuCEN.New_(usu.Nombre, usu.Pass, usu.Email, usu.FechaNacimiento, usu.Genero, usu.Estado,
                    usu.Imagen, usu.Apellido, usu.Tipo == "A" ? ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.administrador : ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);
                }
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
                UsuarioEN usuBefore = usuRepo.GetID(usu.Email);
                usuCEN.Modify(id, usu.Nombre, usu.Pass, usu.FechaNacimiento, usu.Genero, usu.Estado, usu.Imagen, usu.Apellido, usu.Tipo == "A"
                ? ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.administrador : ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.TipoUsuarioEnum.estandar);

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
        // GET: UsuarioController/Signout
        public ActionResult Signout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // GET: UsuarioController/Unathorize
        public ActionResult Unathorize()
        {
            return View();
        }


        // GET: UsuarioController/Me
        public ActionResult Me()
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction(nameof(Login));
            }

            SessionInitialize();
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            UsuarioEN usuEN = usuarioCEN.GetID(user.Email);

            IEnumerable<AlbumViewModel> albumesFavs = new AlbumAssembler().ConvertirListENToViewModel(usuEN.Album_favoritos).ToList();
            IEnumerable<AlbumViewModel> albumesComprados = new AlbumAssembler().ConvertirListENToViewModel(usuEN.Album).ToList();
            IEnumerable<ArtistaViewModel> artistasFavs = new ArtistaAssembler().ConvertirListENToViewModel(usuEN.Artista_favoritos).ToList();

            ViewData["albumesFavs"] = albumesFavs;
            ViewData["albumesComprados"] = albumesComprados;
            ViewData["artistasFavs"] = artistasFavs;

            SessionClose();



            return View(user);
        }
    }

}