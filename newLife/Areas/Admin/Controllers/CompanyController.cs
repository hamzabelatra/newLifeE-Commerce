using Microsoft.AspNetCore.Mvc;
using newLife.DataAccess.Repositry.IRepositry;
using newLife.Models;

namespace newLife.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Upsert(int? id)
        {
            Company company = new();



            if (id == null || id == 0)
            {

                return View(company);
            }
            else
            {
                //update Company
                company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);

            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["EditCT"] = "Company Added successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["EditCT"] = "Company edited successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companylist = _unitOfWork.Company.GetAll();
            return Json(new { data = companylist });
        }


        [HttpDelete]


        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }



            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });


        }
        #endregion

    }
}

