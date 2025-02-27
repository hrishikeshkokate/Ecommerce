﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;


        }
        // GET: UserController
        public ActionResult Index()
        {
            var model = service.GetUsers();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var user = service.GetUserById(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users user)
        {
            try
            {
                int result = service.AddUser(user);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = service.GetUserById(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Users user)
        {
            try
            {
                int result = service.EditUser(user);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = service.GetUserById(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteUser(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users login)
        {


            try
            {
                var user = service.GetUserByEmail(login.Email);

                // Check if the user exists and the password matches
                if (user != null && user.Password == login.Password)
                {
                    if (user.IsActive != 1) // Assuming 1 means active and 0 means inactive
                    {
                        ViewBag.ErrorMsg = "Your account is inactive. Please contact admin.";
                        return View(login);
                    }


                    // Store the user's email, userid and role in session
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetInt32("UserRole", user.RoleId);
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    // Check the role of the user
                    if (user.RoleId == 1) // Assuming 1 is the role ID for admin
                    {
                        // Store the admin's email in session
                        // HttpContext.Session.SetString("UserEmail", login.Email);

                        // Redirect to the product dashboard
                        return RedirectToAction("Index", "Product");
                    }
                    else if (user.RoleId == 2) // Assuming 2 is the role ID for customer
                    {
                        // Store the customer's email in session
                        // HttpContext.Session.SetString("UserEmail", login.Email);

                        // Redirect to the product list
                        return RedirectToAction("ProductList", "Product");

                    }
                }

                // If user or password is incorrect
                ViewBag.ErrorMsg = "Invalid email or password";
                return View(login);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(login);
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult UpdateStatus(int userId, int isActive)
        {
            service.UpdateUserStatus(userId, isActive);
            return RedirectToAction("Index");
        }
    }
}
