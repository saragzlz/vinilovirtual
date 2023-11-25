﻿using InterfazViniloVirtual.Assemblers;
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
        // GET: ArtistaController
        public ActionResult Index()
        {
            SessionInitialize();
            ArtistaRepository artistaRepository = new ArtistaRepository(session);
            ArtistaCEN artistaCEN = new ArtistaCEN(artistaRepository);

            IList<ArtistaEN> listEN = artistaCEN.GetAll(0, -1);

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
        public ActionResult Create(ArtistaViewModel art)
        {
            try
            {
                ArtistaRepository artRepo = new ArtistaRepository();
                ArtistaCEN artCEN = new ArtistaCEN(artRepo);
                artCEN.New_(art.nombre, art.descripcion, art.imagen);

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