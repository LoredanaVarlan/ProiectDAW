using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect_DAW.Repository;
using System.Data;

namespace Proiect_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class UtilizatorController : Controller
    {

        private IUtilizatorRepository utilizatorRepository;

        public UtilizatorController()
        {
            this.utilizatorRepository = new UtilizatorRepository(new BookReviewContext());

        }

        public UtilizatorController(IUtilizatorRepository utilizatorRepository)
        {
            this.utilizatorRepository = utilizatorRepository;
        }


        public static List<Utilizator> utilizatori = new List<Utilizator>();

       


        [HttpGet]
        //get.Utilizator
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var utilizator = from s in utilizatorRepository.GetUtilizator()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                utilizator = utilizator.Where(s => s.Nume.ToUpper().Contains(searchString.ToUpper())
                                       || s.Prenume.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    utilizator = utilizator.OrderByDescending(s => s.Nume);
                    break;
                default:  // Name ascending 
                    utilizator = utilizator.OrderBy(s => s.Nume);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(utilizator);
        }

        private ViewResult View(object p)
        {
            throw new NotImplementedException();
        }


        //get/utilizator/details


        public ViewResult Details(int id)
        {
            Utilizator utilizator = utilizatorRepository.GetUtilizatorByID(id);
            return View(utilizator);
        }

        //get/Utilizator/create
        public ActionResult Create()
        {
            return View();
        }


      
        //post/utilizator/create
        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public ActionResult Create(
         [Bind("Nume, Prenume, Varsta, Email")]
           Utilizator utilizator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    utilizatorRepository.InsertUtilizator(utilizator);
                    utilizatorRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(utilizator);
        }

        //get/utilizator/edit

        public ActionResult Edit(int id)
        {
            Utilizator utilizator = utilizatorRepository.GetUtilizatorByID(id);
            return View(utilizator);
        }

        //post/utilizator/edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
         [Bind("LastName, FirstMidName, EnrollmentDate")]
         Utilizator utilizator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    utilizatorRepository.UpdateUtilizator(utilizator);
                    utilizatorRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(utilizator);
        }


        /*
        [HttpPatch("{id}")]
        public IActionResult Patch ([FromRoute] int id, [FromBody] JsonPatchDocument<Utilizator> obUtil)
        {
            if(obUtil != null)
            {
                var utilToUpdate = utilizatori.FirstOrDefault(_util => _util.Id.Equals(id));
                obUtil.ApplyTo(utilToUpdate, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return Ok(utilizatori);
            }
            else
            {
                return BadRequest();
            }

        }

        */


        //get/utilizator/delete
        [HttpDelete]

        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Utilizator utilizator = utilizatorRepository.GetUtilizatorByID(id);
            return View(utilizator);
        }

        //post/utilizator/delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Utilizator utilizator = utilizatorRepository.GetUtilizatorByID(id);
                utilizatorRepository.DeleteUtilizator(id);
                utilizatorRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            utilizatorRepository.Dispose();
            base.Dispose(disposing);
        }
    }

}

