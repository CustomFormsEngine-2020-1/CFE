using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using CFE.BLL.BL;
using CFE.Infrastructure.Interfaces;
using CFE.ViewModels.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFE.WebUI.Controllers
{
    public class FormController : Controller
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private FormBL formBL;
        private QuestionBL questionBL;
        private AnswerBL answerBL;
        private ElementBL elementBL;
        private AttributeBL attributeBL;
        public FormController(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
            formBL = new FormBL(mapper, unitOfWork);
            questionBL = new QuestionBL (mapper, unitOfWork);
            answerBL = new AnswerBL (mapper, unitOfWork);
            elementBL = new ElementBL (mapper, unitOfWork);
            attributeBL = new AttributeBL(mapper, unitOfWork);
        }
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        // GET: Form/Details/
        public ActionResult Details() => View(mapper.Map<List<FormViewModel>>(formBL.ReadAll()));

        // GET: Form/Details/5
        public ActionResult Details(int id) => View(mapper.Map<FormViewModel>(formBL.Read(id)));

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] JsonElement value)
        {
            try
            {
                // TODO: Add insert logic here
                var json = value.GetRawText();
                var formCreateViewModel = JsonSerializer.Deserialize<FormCreateViewModel>(json);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}