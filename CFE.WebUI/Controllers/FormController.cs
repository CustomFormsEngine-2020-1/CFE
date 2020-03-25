using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper mapper;
        private IUnitOfWork unitOfWork;
        private FormBL formBL;
        public FormController(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
            formBL = new FormBL(mapper, unitOfWork);
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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