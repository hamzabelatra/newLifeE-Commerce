using Microsoft.AspNetCore.Mvc;
using newLife.DataAccess.Repositry.IRepositry;
using newLife.Models;

namespace newLife.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTyperController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTyperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverTyper> objCovertyperList = _unitOfWork.CoverType.GetAll();
            return View(objCovertyperList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverTyper obj)
        {
            if (obj.Name == "fuck")
            {
                ModelState.AddModelError("Custom Error", "The DisplayOrder cannot excatly match test");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["SuccessCT"] = "Cover Typer added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverTyper obj)
        {
            if (obj.Name == "fuck")
            {
                ModelState.AddModelError("Custom Error", "The DisplayOrder cannot excatly match test");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["EditCT"] = "Cover Typer edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var categoryfromDb = _db.categories.Find(id);
            var categoryFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["deletedCT"] = "Cover Typer deleted successfully";

            return RedirectToAction("Index");


        }

    }
}

