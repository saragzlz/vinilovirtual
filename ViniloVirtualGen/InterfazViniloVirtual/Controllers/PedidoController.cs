using InterfazViniloVirtual.Assemblers;
using InterfazViniloVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViniloVirtualGen.ApplicationCore.CEN.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.CP.ViniloVirtual;
using ViniloVirtualGen.ApplicationCore.EN.ViniloVirtual;
using ViniloVirtualGen.Infraestructure.CP;
using ViniloVirtualGen.Infraestructure.Repository.ViniloVirtual;

namespace InterfazViniloVirtual.Controllers
{
    public class PedidoController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;

        public PedidoController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: ArtistaController
        public ActionResult VerCarrito()
        {
            SessionInitialize();

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            PedidoViewModel carrito = HttpContext.Session.Get<PedidoViewModel>("pedido");

            if (carrito != null && carrito.LineasPedido.Count > 0)
            {
                LineaPedidoRepository lineaPedidoRepository = new LineaPedidoRepository(session);
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaPedidoRepository);

                IList<AlbumViewModel> albumes = new List<AlbumViewModel>();
                double total = 0;
                foreach (int x in carrito.LineasPedido)
                {
                    LineaPedidoEN pedidoEn = lineaPedidoCEN.GetID(x);
                    albumes.Add(new AlbumAssembler().ConvertirENToViewModel(pedidoEn.Album));
                    total += pedidoEn.Album.Precio;
                }
                carrito.Total = Math.Round(total, 2);

                ViewData["albumes"] = albumes;


                SessionClose();

                return View(carrito);

            }
            else
            {
                SessionClose();
                return RedirectToAction("Explorer", "Album");
            }




        }

        public ActionResult Create()
        {
            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");

            if (user == null || user.Tipo == "C")
            {
                return RedirectToAction("Login", "Usuario");
            }

            AlbumViewModel albumViewModel = new AlbumViewModel();
            ArtistaRepository artsRepos = new ArtistaRepository();
            ArtistaCEN artsEN = new ArtistaCEN(artsRepos);
            albumViewModel.ArtistaENs = artsEN.GetAll(0, -1).ToList();

            return View(albumViewModel);
        }

        public ActionResult EliminarAlbum(int id)
        {
            SessionInitialize();

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            LineaPedidoRepository lineaPedidoRepository = new LineaPedidoRepository(session);
            LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaPedidoRepository);

            PedidoViewModel carrito = HttpContext.Session.Get<PedidoViewModel>("pedido");

            PedidoCP pedidoCP = new PedidoCP(new SessionCPNHibernate());

            List<int> pedidos = pedidoCP.RemoveLineaPedido(carrito.Id, id);

            carrito.LineasPedido = pedidos;

            double total = 0;
            foreach (int x in carrito.LineasPedido)
            {
                LineaPedidoEN pedidoEn = lineaPedidoCEN.GetID(x);
                total += pedidoEn.Album.Precio;
            }
            carrito.Total = total;
            HttpContext.Session.Set<PedidoViewModel>("pedido", carrito);

            SessionClose();

            return RedirectToAction(nameof(VerCarrito));

        }

        public ActionResult MetodoPago(string metodo)
        {
            SessionInitialize();

            UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (user == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            PedidoViewModel carrito = HttpContext.Session.Get<PedidoViewModel>("pedido");

            carrito.MetodoPago = metodo;

            carrito.SeleccionMetodo = true;
            HttpContext.Session.Set<PedidoViewModel>("pedido", carrito);

            return RedirectToAction(nameof(VerCarrito));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pagar(PedidoViewModel com)
        {
            try
            {
                UsuarioViewModel user = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                if (user == null)
                {
                    return RedirectToAction("Login", "Usuario");
                }

                PedidoViewModel carrito = HttpContext.Session.Get<PedidoViewModel>("pedido");

                if (!carrito.SeleccionMetodo)
                {
                    HttpContext.Session.Set<string>("error", "Debes seleccionar un método de pago");
                    return RedirectToAction(nameof(VerCarrito));
                }
                HttpContext.Session.Set<string>("error", "");
                UsuarioCP cP = new UsuarioCP(new SessionCPNHibernate());

                LineaPedidoRepository lineaPedidoRepository = new LineaPedidoRepository();
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN(lineaPedidoRepository);



                foreach (int x in carrito.LineasPedido)
                {
                    LineaPedidoEN pedidoEn = lineaPedidoCEN.GetID(x);
                    cP.AddAlbumBuy(pedidoEn.Album.Id, user.Email);

                }

                carrito.LineasPedido = new List<int>();

                HttpContext.Session.Set<PedidoViewModel>("pedido", carrito);

                return RedirectToAction("Me", "Usuario");
            }
            catch
            {
                return View();
            }
        }
    }
}