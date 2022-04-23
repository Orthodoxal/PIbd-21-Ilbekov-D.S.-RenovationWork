﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RenovationWorkClientApp.Models;
using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace RenovationWorkClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }
        [HttpPost]
        public void Privacy(string login, string password, string fullname)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
                && !string.IsNullOrEmpty(fullname))
            {
                APIClient.PostRequest("api/client/updatedata", new
                ClientBindingModel
                {
                    Id = Program.Client.Id,
                    Fullname = fullname,
                    Login = login,
                    Password = password
                });
                Program.Client.Fullname = fullname;
                Program.Client.Login = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Enter login, password and fullname");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client =
                APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Uncorrect login or password");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Enter login, password");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string password, string fullname)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(fullname))
            {
                APIClient.PostRequest("api/client/register", new
                ClientBindingModel
                {
                    Fullname = fullname,
                    Login = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Enter login, password and fullname");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Repairs = APIClient.GetRequest<List<RepairViewModel>>("api/main/getrepairlist");
            return View();
        }
        [HttpPost]
        public void Create(int repair, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/createorder", new OrderViewModel
            {
                RepairId = repair,
                Count = count,
                Sum = sum,
                ClientId = Program.Client.Id
            });
            Response.Redirect("Index");
        }
        [HttpPost]
        public decimal Calc(decimal count, int repair)
        {
            RepairViewModel prod = APIClient.GetRequest<RepairViewModel>($"api/main/getrepair?repairId={repair}");
            return count * prod.Price;
        }
    }
}

