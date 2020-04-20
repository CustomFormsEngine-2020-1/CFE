using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CFE.BLL.BL;
using CFE.ViewModels.VM;
using CFE.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CFE.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private UserBL userCreateBL;

        public AccountController(IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                userCreateBL = new UserBL(mapper, unitOfWork);
                userCreateBL.Create(userViewModel);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Register");
            }
        }
    }
}