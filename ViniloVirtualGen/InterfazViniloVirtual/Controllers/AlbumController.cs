using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.IRepository.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;
using System.Globalization;
using ViniloVirtualGen.ApplicationCore.Enumerated.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.CP;

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

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            ViewData["usuario"] = user;
            SessionClose();

            return View(listAlbumes);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            AlbumRepository albRepo = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepo);
            UsuarioRepository usuarioRepository = new UsuarioRepository(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepository);

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");



            AlbumEN albEN = albCEN.GetID(id);

            AlbumViewModel albView = new AlbumAssembler().ConvertirENToViewModel(albEN);


            if (user != null)
            {
                UsuarioEN usu = usuarioCEN.GetID(user.Email);

                foreach (AlbumEN x in usu.Album_favoritos)
                {
                    if (x.Id == albView.Id)
                    {
                        albView.IsFav = true;
                        break;
                    }
                }
            }

            IEnumerable<ComentarioAlbViewModel> comentView = new ComentarioAlbAssembler().ConvertirListENToViewModel(albEN.ComentarioAlb);

            ViewData["Comentarios"] = comentView;

            SessionClose();
            return View(albView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                AlbumCEN albCEN = new AlbumCEN(albRepo);
                UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

                foreach (int x in user.album_favoritos)
                {
                    if (x == alb.Id)
                    {
                        alb.IsFav = true;
                        break;
                    }
                }

                if (!alb.IsFav)
                {
                    albCEN.AnyadirFavorito(alb.Id, new List<string>() { user.Email });
                    albCEN.IncrementoLikes(alb.Id);
                    user.album_favoritos.Add(alb.Id);
                    HttpContext.Session.Set<UsuarioViewModel>("usuario", user);

                }
                else
                {
                    albCEN.EliminarFavorito(alb.Id, new List<string>() { user.Email });
                    albCEN.DecrementoLikes(alb.Id);
                    user.album_favoritos.Remove(alb.Id);
                    HttpContext.Session.Set<UsuarioViewModel>("usuario", user);
                }

                return RedirectToAction("Details", "Album", new { id = alb.Id });

            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }

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
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }
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
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Unathorize", "Usuario");
            }
            AlbumRepository albRepo = new AlbumRepository();
            AlbumCEN albCEN = new AlbumCEN(albRepo);
            albCEN.EliminarListaAlbumesCompra(id);
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

        // GET: AlbumController
        public ActionResult Explorer(int genero)
        {
            SessionInitialize();

            AlbumRepository albRepository = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepository);

            IList<AlbumEN> listEN = null;
            if (genero != 0)
            {
                var generos = Enum.GetValues(typeof(GeneroMusicalEnum));
                genero--;
                GeneroMusicalEnum generoFilter = (GeneroMusicalEnum)generos.GetValue(genero);
                listEN = albCEN.GetAlbumsDelGenero(generoFilter);

            }
            else
            {
                listEN = albCEN.GetAll(0, -1);
            }


            IEnumerable<AlbumViewModel> listAlbumes = new AlbumAssembler().ConvertirListENToViewModel(listEN).ToList();

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            ViewData["usuario"] = user;

            ViewData["albumes"] = listAlbumes;
            SessionClose();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Explorer(FiltroViewModel alb)
        {
            try
            {
                SessionInitialize();

                AlbumRepository albRepository = new AlbumRepository(session);
                AlbumCEN albCEN = new AlbumCEN(albRepository);

                IList<AlbumEN> listEN = albCEN.GetAll(0, -1);

                listEN = listEN.Where(x => x.Artista.Nombre.ToLower().Contains(alb.TextoBuscar.ToLower()) || x.Nombre.ToLower().Contains(alb.TextoBuscar.ToLower())).ToList();

                IEnumerable<AlbumViewModel> listAlbumes = new AlbumAssembler().ConvertirListENToViewModel(listEN).ToList();

                SessionClose();
                ViewData["albumes"] = listAlbumes;
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult VerCarrito(int genero)
        {
            SessionInitialize();

            AlbumRepository albRepository = new AlbumRepository(session);
            AlbumCEN albCEN = new AlbumCEN(albRepository);

            IList<AlbumEN> listEN = null;
            if (genero != 0)
            {
                var generos = Enum.GetValues(typeof(GeneroMusicalEnum));
                genero--;
                GeneroMusicalEnum generoFilter = (GeneroMusicalEnum)generos.GetValue(genero);
                listEN = albCEN.GetAlbumsDelGenero(generoFilter);

            }
            else
            {
                listEN = albCEN.GetAll(0, -1);
            }


            IEnumerable<AlbumViewModel> listAlbumes = new AlbumAssembler().ConvertirListENToViewModel(listEN).ToList();

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            ViewData["usuario"] = user;

            ViewData["albumes"] = listAlbumes;
            SessionClose();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarrito(AlbumViewModel alb)
        {
            try
            {
                AlbumRepository albRepo = new AlbumRepository();
                AlbumCEN albCEN = new AlbumCEN(albRepo);
                LineaPedidoRepository lineaPedidoRepository = new LineaPedidoRepository();
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaPedidoRepository);
                PedidoRepository pedidoRepository = new PedidoRepository();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoRepository);

                AlbumEN albumEN = albCEN.GetID(alb.Id);

                UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

                PedidoViewModel pedidoSave = HttpContext.Session.Get<PedidoViewModel>("pedido");

                PedidoCP pedidoCP = new PedidoCP(new SessionCPNHibernate());

                PedidoEN pedidoEN = null;

                if (pedidoSave != null)
                {
                    pedidoEN = pedidoCEN.GetID(pedidoSave.Id);


                }
                else
                {
                    int pedido = pedidoCEN.New_(DateTime.Now, "", albumEN.Precio, MetodosPagoEnum.visa, EstadoPedidoEnum.pendiente, user.Email);

                    pedidoEN = pedidoCEN.GetID(pedido);

                }


                List<int> pedidos = pedidoCP.AddLineaPedido(pedidoEN.Id, albumEN.Id);

                

                PedidoViewModel pedidoViewModel = new PedidoAssembler().ConvertirENToViewModel(pedidoEN);
                pedidoViewModel.LineasPedido = pedidos;

                HttpContext.Session.Set<PedidoViewModel>("pedido", pedidoViewModel);



                return RedirectToAction("Details", "Album", new { id = alb.Id });

            }
            catch
            {
                return View();
            }
        }
    }
}
