using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class ArtistaController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;

        public ArtistaController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: ArtistaController
        public ActionResult Index()
        {
            SessionInitialize();
            ArtistaRepository artistaRepository = new ArtistaRepository(session);
            ArtistaCEN artistaCEN = new ArtistaCEN(artistaRepository);

            IList<ArtistaEN> listEN = artistaCEN.GetAll(0, -1);

            UsuarioViewModel user =  HttpContext.Session.Get<UsuarioViewModel>("usuario");
            ViewData["usuario"] = user;

            IEnumerable<ArtistaViewModel> listArtistas = new ArtistaAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listArtistas);
        }

        // GET: ArtistaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ArtistaRepository artRepo = new ArtistaRepository(session);
            ArtistaCEN artCEN = new ArtistaCEN(artRepo);

            ArtistaEN artEN = artCEN.GetID(id);
            ArtistaViewModel artView = new ArtistaAssembler().ConvertirENToViewModel(artEN);

            AlbumRepository albumRepository = new AlbumRepository(session);
            AlbumCEN albumCEN = new AlbumCEN(albumRepository);
            List<AlbumEN> albumsEN = new List<AlbumEN>();

            albumsEN.AddRange(albumCEN.GetAlbumesArtista(id));
            // albumsEN = albumCEN.GetAlbumesArtista(id);

            IEnumerable<AlbumViewModel> albumesArtista = new AlbumAssembler().ConvertirListENToViewModel(albumsEN).ToList();

            ViewData["albumesArtista"] = albumesArtista;

            SessionClose();
            return View(artView);
        }

        // GET: ArtistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArtistaViewModel art)
        {
            try
            {
                ArtistaRepository artRepo = new ArtistaRepository();
                ArtistaCEN artCEN = new ArtistaCEN(artRepo);
            

                string fileName = "", path = "";
                if (art.Fichero != null && art.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(art.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await art.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    artCEN.New_(art.nombre, art.descripcion, fileName);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ArtistaRepository artRepo = new ArtistaRepository(session);
            ArtistaCEN artCEN = new ArtistaCEN(artRepo);

            ArtistaEN artEN = artCEN.GetID(id);
            ArtistaViewModel artView = new ArtistaAssembler().ConvertirENToViewModel(artEN);

            SessionClose();
            return View(artView);
        }
        /*
        // POST: ArtistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtistaViewModel art)
        {
            try
            {

                ArtistaRepository artRepo = new ArtistaRepository();
                ArtistaCEN artCEN = new ArtistaCEN(artRepo);
                artCEN.Modify(id, art.nombre, art.descripcion, art.imagen);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */

        // POST: ArtistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ArtistaViewModel art)
        {
            try
            {
                ArtistaRepository artRepo = new ArtistaRepository();
                ArtistaCEN artCEN = new ArtistaCEN(artRepo);


                string fileName = "", path = "";
                if (art.Fichero != null && art.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(art.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await art.Fichero.CopyToAsync(stream);
                    }

                    fileName = "/Images/" + fileName;
                    artCEN.Modify(id, art.nombre, art.descripcion, fileName);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: ArtistaController/Delete/5
        public ActionResult Delete(int id)
        {

            ArtistaRepository artRepo = new ArtistaRepository();
            ArtistaCEN artCEN = new ArtistaCEN(artRepo);
            artCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: ArtistaController/Delete/5
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
