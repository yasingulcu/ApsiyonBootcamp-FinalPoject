using Apsiyon.Application.Interfaces;
using Apsiyon.Domain.Models;
using Apsiyon.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apsiyon.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;
        private readonly UserManager<User> _userManager;
        private readonly IUnitofWork _unitofWork;

        public FlatController(IUnitofWork unitofWork, IFlatService flatService, UserManager<User> userManager)
        {
            _flatService = flatService;
            _userManager = userManager;
            _unitofWork = unitofWork;
        }

        public async Task<IActionResult> AddFlat()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Name");
            List<Flat> flats = await _unitofWork.Flat.GetAll();
            ViewBag.Flats = new List<Flat>(flats);
            ViewBag.UserList = new List<User>(users);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFlat(Flat model)
        {
            if (ModelState.IsValid)
            {
                await _unitofWork.Flat.Add(model);
                await _unitofWork.SaveChangesAsync();
                return RedirectToAction("AddFlat");
            }
            return RedirectToAction("AddFlat");
        }

        public async Task<IActionResult> Delete(int flatId)
        {
            List<Flat> flatList = await _unitofWork.Flat.Get(x => x.Id == flatId);
            Flat flat = flatList.FirstOrDefault();
            if (flat != null)
            {
                List<Subscription> subscriptions1 = await _unitofWork.Subscription.Get(x => x.FlatId == flat.Id);
                foreach (Subscription item in subscriptions1)
                {
                    _unitofWork.Subscription.Delete(item);
                }
                List<Subscription> subscriptions = await _unitofWork.Subscription.Get(x => x.FlatId == flat.Id);
                foreach (Subscription item in subscriptions)
                {
                    _unitofWork.Subscription.Delete(item);
                }

                _unitofWork.Flat.Delete(flat);
                await _unitofWork.SaveChangesAsync();
            }
            return RedirectToAction("AddFlat");
        }
        public async Task<IActionResult> Update(int flatId)
        {
            var users = _userManager.Users.ToList();
            ViewBag.Users = new SelectList(users, "Id", "UserName");
            List<Flat> flat = await _unitofWork.Flat.Get(x => x.Id == Convert.ToInt32(flatId));
            return View(flat.FirstOrDefault());
        }
        [HttpPost]
        public async Task<IActionResult> Update(Flat model)
        {
            List<Flat> flatList = await _unitofWork.Flat.Get(x => x.Id == model.Id);
            Flat flat = flatList.FirstOrDefault();
            flat.UserId = model.UserId;
            _unitofWork.Flat.Update(flat);
            await _unitofWork.SaveChangesAsync();
            return RedirectToAction("AddFlat");
        }
    }
}
