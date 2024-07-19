using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        // 44
        // Öncelikle değişgenlerimizi tanımlayalım

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        [AllowAnonymous] // Böylelikle sisteme giriş yapmamış kullanıcılar direkt olarak Login sayfasına yönlendirilmesi sağlanır.
        //Get
        public IActionResult Login()
        {
            var response= new LoginVM();

            return View(response); //...
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EMailAddress);

            if (user != null)
            {
                // Eğer kullanıcı varsa şimdi de password ünü kontrol
                var passwordCheck=await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded) 
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }

                TempData["Error"] = "Wrong credentials. Please try again!";

                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please try again!";

            return View(loginVM);


        }

        public IActionResult Register()
        {
            // Bizi register ekranına götüren metod
            var response = new RegisterVM();

            return View(response);
        }

        // 49
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                // Eğer modelimizde herhangi bir uyumsuz varsa tekrardan Register ekranına geri dönüyoruz.
                return View(registerVM);
            }
            // model durumum uygunsa

            // yeni kayıt olan kullanıcının girdiği mail adresi kayıtlarda var mı?
            var user = await _userManager.FindByEmailAsync(registerVM.EMailAddress);

            if (user != null) 
            {
                // Daha önceden aynı mail adresiyle demek ki bir kayır var.
                TempData["Error"] = "Bu mail adresi kullanımdadır. Lütfen başka bir mail adresi giriniz...";

                return View(registerVM);

            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EMailAddress,
                UserName = registerVM.EMailAddress,
                EmailConfirmed = true
            };

            var newUserResponse= await _userManager.CreateAsync(newUser,registerVM.Password);

            // Buradan işlemin olup olmadığı konusunda bir response gelecek. Bunun durumuna göre işleme devam edeceğiz.

            if (newUserResponse.Succeeded)
            {
                // İşlem başarılıysa
                // bu kullanıcıya standard user rolünü tanımla
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("RegistrationCompleted");
            }
            else
            {
                return View(registerVM);
            }
        }

        // 49.1
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Movies");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }

        // 66
        public async Task<IActionResult> Users()
        {
            var usersData = await _service.GetAllAsync(); // Artık Service yapısı kullanılıyor.

            return View(actorsData);
    }
    }
}
