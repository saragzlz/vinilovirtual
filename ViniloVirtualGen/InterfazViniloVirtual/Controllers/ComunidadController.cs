using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class ComunidadController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public ComunidadController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

            IList<ComunidadEN> listEN = comunidadCEN.GetAll(0, -1);

            IEnumerable<ComunidadViewModel> listComunidad = new ComunidadAssembler().ConvertirListENToViewModel(listEN).ToList();
            ViewData["usuario"] = user;
            SessionClose();

            return View(listComunidad);
        }

        public ActionResult Details(int id)
        {
            SessionInitialize();
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ComunidadRepository comRepo = new ComunidadRepository(session);
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            ComunidadEN comEN = comCEN.GetID(id);

            ComunidadViewModel comView = new ComunidadAssembler().ConvertirENToViewModel(comEN);

            IEnumerable<ComentarioComViewModel> comentView = new ComentarioComAssembler().ConvertirListENToViewModel(comEN.ComentarioCom);

            bool suscrito = false;

            foreach (UsuarioEN x in comEN.Usuario)
            {
                if (x.Email == user.Email)
                {
                    suscrito = true;
                    break;
                }
            }

            ViewData["Comentarios"] = comentView;
            ViewData["suscrito"] = suscrito;

            SessionClose();
            return View(comView);
        }

        // GET: ComunidadController/Create
        public ActionResult Create()
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }
            return View();
        }

        // POST: ComunidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ComunidadViewModel com)
        {
            try
            {
                ComunidadRepository comRepo = new ComunidadRepository();
                ComunidadCEN comCEN = new ComunidadCEN(comRepo);


                string fileName = "", path = "";
                if (com.Fichero != null && com.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(com.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await com.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    comCEN.New_(com.Nombre, fileName, 0);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }
            SessionInitialize();
            ComunidadRepository comRepo = new ComunidadRepository(session);
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            ComunidadEN comEN = comCEN.GetID(id);
            ComunidadViewModel comView = new ComunidadAssembler().ConvertirENToViewModel(comEN);

            SessionClose();
            return View(comView);
        }

        public ActionResult Suscribirse(int id)
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");


            ComunidadRepository comRepo = new ComunidadRepository();
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            comCEN.SeguirComunidad(id, new List<string>() { user.Email });

            comCEN.IncrementoSeguidores(id);

            int copyId = id;

            return RedirectToAction("Details", "Comunidad", new { id = copyId });
        }

        public ActionResult DarBaja(int id)
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");


            ComunidadRepository comRepo = new ComunidadRepository();
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            comCEN.AbandonarComunidad(id, new List<string>() { user.Email });

            comCEN.DecrementoSeguidores(id);

            int copyId = id;

            return RedirectToAction("Details", "Comunidad", new { id = copyId });
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComunidadViewModel com)
        {
            try
            {

                ComunidadRepository comRepo = new ComunidadRepository();
                ComunidadCEN comCEN = new ComunidadCEN(comRepo);
                comCEN.Modify(id, com.Nombre, com.Imagen, com.NumMiembros);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */

        // POST: ComunidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ComunidadViewModel com)
        {
            try
            {
                ComunidadRepository comRepo = new ComunidadRepository();
                ComunidadCEN comCEN = new ComunidadCEN(comRepo);


                string fileName = "", path = "";
                if (com.Fichero != null && com.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(com.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await com.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    comCEN.Modify(id, com.Nombre, fileName, com.NumMiembros);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }

            ComunidadRepository comRepo = new ComunidadRepository();
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);
            comCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

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

        public ActionResult SeguirComunidad(int id)
        {
            SessionInitialize();
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

            if (user.Estado == ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual.EstadoUsuarioEnum.normal)
            {

            }



            IList<ComunidadEN> listEN = comunidadCEN.GetAll(0, -1);

            IEnumerable<ComunidadViewModel> listComunidad = new ComunidadAssembler().ConvertirListENToViewModel(listEN).ToList();
            ViewData["usuario"] = user;
            SessionClose();

            return View(listComunidad);
        }
    }
}
