using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsers());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User entity)
        {
            await _userService.CreateUser(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User entity)
        {
            await _userService.UpdateUser(entity);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            var user = await _userService.GetUserById(id);
            await _userService.DeleteUser(user);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
