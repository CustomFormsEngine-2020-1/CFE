using AutoMapper;
using CFE.BLL.BL;
using CFE.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CFE.WebUI.Controllers
{
    public class FormController : Controller
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private MainFormBL mainFormBL;
        // private FormBL formBL;
        public FormController(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
            mainFormBL = new MainFormBL(mapper, unitOfWork);
            // formBL = new FormBL(mapper, unitOfWork);
        }
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            ViewBag.Forms = mainFormBL.ReadAll();
            return View("Forms");
        }
        // GET: Form/Details/
        public ActionResult Details() => View();

        // GET: Form/Details/5
        //public ActionResult Details(int id) => View(mainFormBL.ResponseForm(id));

        // GET: Form/Create
        public ActionResult Create() => View();

        // POST: Form/Create
        [HttpPost]
        public ActionResult Create([FromBody] JsonElement jsonElement)
        {
            try
            {
                // TODO: Add insert logic here
                mainFormBL.CreateForm(jsonElement);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id) => View(mainFormBL.ResponseForm(id));

        // POST: Form/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JsonElement jsonElement)
        {
            try
            {
                // TODO: Add update logic here
                mainFormBL.UpdateForm(jsonElement);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            mainFormBL.DeleteForm(id);
            return View();
        }

        // POST: Form/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                mainFormBL.DeleteForm(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}