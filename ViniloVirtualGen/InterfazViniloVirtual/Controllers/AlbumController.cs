using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;
using System.Globalization;

namespace InterfazViniloVirtual.Controllers
{
    public class AlbumController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public AlbumController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: AlbumController
        public ActionResult Index()
        {
            SessionInitialize();

            AlbumRepository albRepository = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepository);

            IList<AlbumEN> listEN = albCEN.GetAll(0, -1);

            IEnumerable<AlbumViewModel> listAlbumes = new AlbumAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listAlbumes);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            AlbumRepository albRepo = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepo);

            AlbumEN albEN = albCEN.GetID(id);

            AlbumViewModel albView = new AlbumAssembler().ConvertirENToViewModel(albEN);

            IEnumerable<ComentarioAlbViewModel> comentView = new ComentarioAlbAssembler().ConvertirListENToViewModel(albEN.ComentarioAlb);

            ViewData["Comentarios"] = comentView;

            SessionClose();
            return View(albView);
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            AlbumViewModel albumViewModel = new AlbumViewModel();
            ArtistaRepository artsRepos = new ArtistaRepository();
            ArtistaCEN artsEN = new ArtistaCEN(artsRepos); 
            albumViewModel.ArtistaENs = artsEN.GetAll(0, -1).ToList();
            
            return View(albumViewModel);
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                AlbumCEN albCEN = new AlbumCEN(albRepo);


                string fileName = "", path = "";
                if (alb.Fichero != null && alb.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(alb.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await alb.Fichero.CopyToAsync(stream);
                    }

                    double precio = Double.Parse(alb.Precio, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-GB"));

                    fileName = "/Images/" + fileName;
                    albCEN.New_(alb.Titulo, alb.Descripcion, alb.Genero, fileName, alb.IdArtista, precio, alb.Likes);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            AlbumRepository albRepo = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepo);

            AlbumEN albEN = albCEN.GetID(id);
            AlbumViewModel albView = new AlbumAssembler().ConvertirENToViewModel(albEN);
            ArtistaRepository artsRepos = new ArtistaRepository();
            ArtistaCEN artsEN = new ArtistaCEN(artsRepos);
            albView.ArtistaENs = artsEN.GetAll(0, -1).ToList();

            SessionClose();
            return View(albView);
            
        }
        /*
        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                ArtistaRepository artsRepos = new ArtistaRepository();

                AlbumCEN albCEN = new AlbumCEN(albRepo);
                ArtistaCEN artsEN = new ArtistaCEN(artsRepos);
                double precio = Double.Parse(alb.Precio, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-GB"));

                albCEN.Modify(id, alb.Titulo, alb.Descripcion, alb.Genero, alb.Portada, precio, alb.Likes);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                AlbumCEN albCEN = new AlbumCEN(albRepo);


                string fileName = "", path = "";
                if (alb.Fichero != null && alb.Fichero.Length > 0)
                {
                    fileName = Path.GetFileName(alb.Fichero.FileName).Trim();
                    string directory = _webHost.WebRootPath + "/Images";
                    path = Path.Combine(directory, fileName);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (var stream = System.IO.File.Create(path))
                    {
                        await alb.Fichero.CopyToAsync(stream);
                    }

                    double precio = Double.Parse(alb.Precio, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("en-GB"));

                    fileName = "/Images/" + fileName;
                    albCEN.Modify(id, alb.Titulo, alb.Descripcion, alb.Genero, fileName, precio, alb.Likes);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            AlbumRepository albRepo = new AlbumRepository();
            AlbumCEN albCEN = new AlbumCEN(albRepo);
            albCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: AlbumController/Delete/5
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
