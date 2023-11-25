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
        public ActionResult Index()
        {
            SessionInitialize();
            ComunidadRepository comunidadRepository = new ComunidadRepository(session);
            ComunidadCEN comunidadCEN = new ComunidadCEN(comunidadRepository);

            IList<ComunidadEN> listEN = ComunidadCEN.GetAll(0, -1);

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

            SessionClose();
            return View(comView);
        }

    
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComunidadViewModel com)
        {
            try
            {
                ComunidadRepository artRepo = new ComunidadRepository();
                ComunidadCEN comCEN = new ComunidadCEN(comRepo);
                comCEN.New_(com.Nombre, com.Imagen, com.NumMiembros);

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
            ComunidadViewModel comView = newComunidadAssembler().ConvertirENToViewModel(comEN);

            SessionClose();
            return View(comView);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComunidadViewModel com)
        {
            try
            {

                ComunidadRepository comRepo = new ComunidadRepository();
                ComunidadCEN comCEN = new ComunidadCEN(comRepo);
                comCEN.Modify(com.Nombre, com.Imagen, com.NumMiembros);

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
