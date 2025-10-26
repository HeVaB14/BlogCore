using BlogCore.AccessData.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IJobsContainer _jobsContainer;
        public CategoriesController(IJobsContainer jobsContainer)
        {
            _jobsContainer = jobsContainer;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
           
        }
        //Para crear una nueva categoria
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _jobsContainer.Category.Add(category);
                _jobsContainer.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        #region Llamadas ala api
        [HttpGet]
        public IActionResult GetAll() {
            return Json(new { data = _jobsContainer.Category.GetAll() });


        }
        
        #endregion
    }
}
