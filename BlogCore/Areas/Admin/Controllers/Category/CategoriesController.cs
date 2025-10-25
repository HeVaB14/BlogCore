using BlogCore.AccessData.Data.Repository.IRepository;
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

        #region Llamadas ala api
        [HttpGet]
        public IActionResult GetAll() {
            return Json(new { data = _jobsContainer.Category.GetAll() });


        }
        
        #endregion
    }
}
