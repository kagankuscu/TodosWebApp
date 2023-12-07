using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TodosWebApp.BusinessLogic.Shared.Abstract;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.Web.Controllers;

[Route("[controller]/[action]")]
public class UserController: Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserViewModel userViewModel)
    {
        var user = _unitOfWork.Users.GetFirstOrDefault(u => u.Username == userViewModel.Username && u.Password == userViewModel.Password);
        if (user == null)
        {
            ViewBag.Message = "Username or password is incorrect";
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.GivenName, user.FirstName ?? ""),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        if(user.IsAdmin)
        {
            claims.Add(new(ClaimTypes.Role, "Admin"));
        }
        else
        {
            claims.Add(new(ClaimTypes.Role, "User"));
        }
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var props = new AuthenticationProperties() 
        {
            IsPersistent = userViewModel.IsRememberMe,
        };
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        return RedirectToAction("Index", "Todo");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UserViewModel userViewModel)
    {
        var user = _unitOfWork.Users.GetFirstOrDefault(u => u.Username == userViewModel.Username);
        if (user != null)
        {
            ViewBag.Message = "Username is already taken";
            return View();
        }
        _unitOfWork.Users.Add(_mapper.Map<User>(userViewModel));
        _unitOfWork.Save();
        return RedirectToAction("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
        return RedirectToAction("Login");
    }

    [HttpPost("{user}")]
    public IActionResult CheckUser(string user, UserViewModel userViewModel)
    {
        if(user == "username")
        {
            bool isUsername = _unitOfWork.Users.GetFirstOrDefault(u => u.Username == userViewModel.Username) == null;
            return Json(new { Username = userViewModel.Username, IsUsername = !isUsername });
        } else if(user == "email")
        {
            bool isEmail = _unitOfWork.Users.GetFirstOrDefault(u => u.Email == userViewModel.Email) == null;
            return Json(new { Email = userViewModel.Email, IsEmail = !isEmail });
        } 
        return Json(new { });
    }
}
