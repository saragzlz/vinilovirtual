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
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

            IList<ComunidadEN> listEN = comunidadCEN.GetAll(0, -1);

            IEnumerable<ComunidadViewModel> listComunidad = new ComunidadAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listComunidad);
        }

        public ActionResult Details(int id)
        {
            SessionInitialize();
            ComunidadRepository comRepo = new ComunidadRepository(session);
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            ComunidadEN comEN = comCEN.GetID(id);

            ComunidadViewModel comView = new ComunidadAssembler().ConvertirENToViewModel(comEN);

            IEnumerable<ComentarioComViewModel> comentView = new ComentarioComAssembler().ConvertirListENToViewModel(comEN.ComentarioCom);

            ViewData["Comentarios"] = comentView;


            SessionClose();
            return View(comView);
        }

        // GET: ComunidadController/Create
        public ActionResult Create()
        {
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
            SessionInitialize();
            ComunidadRepository comRepo = new ComunidadRepository(session);
            ComunidadCEN comCEN = new ComunidadCEN(comRepo);

            ComunidadEN comEN = comCEN.GetID(id);
            ComunidadViewModel comView = new ComunidadAssembler().ConvertirENToViewModel(comEN);

            SessionClose();
            return View(comView);
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
    }
}
