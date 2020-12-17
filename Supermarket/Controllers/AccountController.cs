using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;  
using Microsoft.AspNetCore.Authentication.Cookies;
using Application.DTOs;
using Application.Interfaces;
using System;
using System.Text;
using Supermarket.ViewModel;

namespace Supermarket.Controllers
{
    
    public class AccountController : Controller
    {
        // private readonly SupermarketDbContext _db;

        // public AccountController(SupermarketDbContext db)
        // {
        //     _db = db;
        // }

        private readonly IEmployeeService employeeService;

        public AccountController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;   
        }

        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(EmployeeDto admin)
        {
            //var _admin = _db.Employees.Where(s => s.Email == admin.Email).FirstOrDefault();
            var _admin = employeeService.GetAdmin(admin.Email);
            if(_admin != null){
                _admin.Password = Decrypt(_admin.Password);
                if(_admin.Password == admin.Password){
                    ClaimsIdentity identity = null;
                    if(_admin.EmployeeGroupId == 1)
                    {
                        identity = new ClaimsIdentity(new[] {  
                            new Claim(ClaimTypes.Name, admin.Email),
                            new Claim(ClaimTypes.Role,"Admin")  
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                    if(_admin.EmployeeGroupId == 2)
                    {
                        identity = new ClaimsIdentity(new[] {  
                            new Claim(ClaimTypes.Name, admin.Email),
                            new Claim(ClaimTypes.Role,"ImportEmployee")  
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    }  
                    if(_admin.EmployeeGroupId == 4)
                    {
                        identity = new ClaimsIdentity(new[] {  
                            new Claim(ClaimTypes.Name, admin.Email),
                            new Claim(ClaimTypes.Role,"SaleEmployee")  
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                        var principal = new ClaimsPrincipal(identity);  
        
                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); 
                    return Json(new { status = true, message = "Đăng nhập thành công!"});
                }
                else {
                    return Json(new { status = false, message = "Mật khẩu không khớp!"});
                }
            }
            else {
                return Json(new { status = false, message = "Tài khoản không tồn tại!"});
            }
        }

        public IActionResult Logout()  
        {  
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
            return RedirectToAction("Login");  
        } 

        public static string Key= "qlstmini@gmail.com";
        // Decrypting a dataBytes to String 
        public static string Decrypt(string base64EncodeData)
        {
            if(string.IsNullOrEmpty(base64EncodeData))
            return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result= Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length- Key.Length);
            return result;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePassword)
        {   
            if(ModelState.IsValid)
            {
                var employee = employeeService.GetEmployee(changePassword.Id);
                employee.Password = Encrypt(changePassword.NewPassword);
                employeeService.UpdateEmployee(employee);

                return View("Login");
            }
            return View();
        }

        public static string Encrypt(string password)
        {
            if(string.IsNullOrEmpty(password))
            return "";
            password+= Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }
    }
}