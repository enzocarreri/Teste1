using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginEscolher()
        {
            return View();
        }
        public ActionResult LoginEmpresa()
        {
            return View();
        }
        public ActionResult LoginCliente()
        {
            return View();
        }

        public ActionResult LogadoCliente()
        {
            string login = Request.QueryString["login"];
            string senha = Request.QueryString["senha"];
            LoginDAO dao = new LoginDAO();
            ViewBag.login = login;
            ViewBag.senha = senha;
            List<ModItensPedidos> ped = dao.ListarPedidosCliente(login, senha);
            return View(ped);
        }

        public ActionResult LogadoEmpresa()
        {
            string login = Request.QueryString["login"];
            string senha = Request.QueryString["senha"];
            LoginDAO dao = new LoginDAO();
            ViewBag.login = login;
            ViewBag.senha = senha;
            List<ModItensPedidos> ped = dao.ListarPedidosEmpresa(login,senha);
           return View(ped);


        }
       
    }
}