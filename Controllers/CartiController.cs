using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_DAW.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartiController : Controller
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        public static List<Carti> carti = new List<Carti>();

        //get/carti
        public ViewResult Index()
        {
            var carti = unitOfWork.CartiRepository.Get(includeProperties: "Titlu");
            return View(carti.ToList());
        }

        //get/carti/details

        public ViewResult Details(int id)
        {
            Carti carti = unitOfWork.CartiRepository.GetByID(id);
            return View(carti);
        }

        //get/carti/create

        public ActionResult Create()
        {
            PopulateAutorDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("IdCarte,Titlu,An_publicare,Autor")]
         Carti carti)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CartiRepository.Insert(carti);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAutorDropDownList(carti.Autor);
            return View(carti);
        }

        public ActionResult Edit(int id)
        {
            Carti carti = unitOfWork.CartiRepository.GetByID(id);
            PopulateAutorDropDownList(carti.Autor);
            return View(carti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind("IdCarte,Titlu,An_publicare,Autor")]
         Carti carti)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CartiRepository.Update(carti);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAutorDropDownList(carti.Autor);
            return View(carti);
        }

        private void PopulateAutorDropDownList(object selectedAutor = null)
        {
            var autoriQuery = unitOfWork.AutoriRepository.Get(
                orderBy: q => q.OrderBy(d => d.Nume));
            ViewBag.IdAutor = new SelectList(autoriQuery, "IdAutor", "Nume", selectedAutor);
        }


        //get/carti/delete
        public ActionResult Delete(int id)
        {
            Carti carti = unitOfWork.CartiRepository.GetByID(id);
            return View(carti);
        }

        //
        // POST/carti/delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carti carti = unitOfWork.CartiRepository.GetByID(id);
            unitOfWork.CartiRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }



    }
}
