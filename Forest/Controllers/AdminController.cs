using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Forest.Models;

namespace Forest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private Forest.Models.ApplicationDbContext _context;
        public AdminController()
        {
            _context = new Forest.Models.ApplicationDbContext();
        }
        //GET: Admin
        
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult GetUsers()
        {
            return View(_context.Users.ToList());
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                Microsoft.AspNet.Identity.EntityFramework.IdentityRole role =
                    new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = collection["RoleName"];
                _context.Roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        }
        [HttpGet]
        public ActionResult ManageUserRoles()
        {
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user =
                _context.Users.Where
                (u => u.UserName.Equals(UserName,
                StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            var idResult = um.AddToRole(user.Id, RoleName);
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select
                (rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text =
                rr.Name
                }).ToList();
            ViewBag.Roles = roleList;
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select
                (uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text =
                uu.UserName
                }).ToList();
            ViewBag.Users = userList;
            return View("ManageUserRoles");
        }
        [HttpGet]
        public ActionResult GetRolesforUser()
        { return View(); }
        [HttpPost][ValidateAntiForgeryToken]
        public ActionResult GetRolesforUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user =
                    _context.Users.Where(u => u.UserName.Equals
                    (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                    (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                ViewBag.RolesforThisUser = um.GetRoles(user.Id);
            }
            return View("GetRolesforUserConfirmed");
        }

    }
}