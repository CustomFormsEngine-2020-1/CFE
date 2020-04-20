using AutoMapper;
using CFE.BLL.BL;
using CFE.ViewModels.VM;
using CFE.ViewModels.VM.Users;
using CFE.Entities.Models;
using CFE.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CFE.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;
        private UserBL userCreateBL;
        private readonly SignInManager<User> _signInManager;
        public AccountController(IMapper _mapper, IUnitOfWork _unitOfWork, SignInManager<User> signInManager)
        {
            mapper = _mapper;
            unitOfWork = _unitOfWork;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
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


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}