using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class AlbumController : BasicController
    {
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
        public ActionResult Create(AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                ArtistaRepository artsRepos = new ArtistaRepository();

                AlbumCEN albCEN = new AlbumCEN(albRepo);
                ArtistaCEN artsEN = new ArtistaCEN(artsRepos); 
                

                albCEN.New_(alb.Titulo, alb.Descripcion, alb.Genero, alb.Portada, alb.IdArtista, alb.Precio, alb.Likes);


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
            AlbumViewModel albView = new AlbumViewModel();
            ArtistaRepository artsRepos = new ArtistaRepository();
            ArtistaCEN artsEN = new ArtistaCEN(artsRepos);
            albView.ArtistaENs = artsEN.GetAll(0, -1).ToList();

            SessionClose();
            return View(albView);
        }

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

                albCEN.Modify(id, alb.Titulo, alb.Descripcion, alb.Genero, alb.Portada, alb.Precio, alb.Likes);
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
