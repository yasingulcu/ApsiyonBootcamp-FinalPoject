using Apsiyon.Domain.Models;
using Apsiyon.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apsiyon.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitofWork _unitofWork;

        public AdminController(IUnitofWork unitofWork, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            ViewBag.UserName = user.UserName;

            var userRoles = await _userManager.GetRolesAsync(user);

            return View(userRoles);
        }

        public async Task<IActionResult> Delete(int userId)
        {
            Flat flat = await _unitofWork.Flat.GetById(x =>x.UserId == userId);
            if (flat != null)
            {
                List<Subscription> subscriptions = await _unitofWork.Subscription.Get(x => x.FlatId == flat.Id);
                foreach (Subscription item in subscriptions)
                {
                    _unitofWork.Subscription.Delete(item);
                }

                _unitofWork.Flat.Delete(flat);
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            await _userManager.DeleteAsync(user);
            await _unitofWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            var result = await _userManager.FindByIdAsync(model.Id);
            result.Name = model.Name;
            result.Surname = model.Surname;
            result.IdentificationNumber = model.IdentificationNumber;
            result.PhoneNumber = model.PhoneNumber;
            result.UserName = model.UserName;
            result.Email = model.Email;
            await _userManager.UpdateAsync(result);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> AddRole(string role)
        //{
        //    await _roleManager.CreateAsync(new IdentityRole(role));
        //    //return RedirectToAction(nameof(DisplayRoles));
        //}


    }
}
