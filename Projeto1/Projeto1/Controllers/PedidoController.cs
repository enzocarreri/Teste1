using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult RealizarPedido()
        {
            string selecionado = Request.QueryString["item"];
            string cliente = Request.QueryString["cliente"];

            string pedido=null;
           
            pedido =selecionado.Replace(",", "");

            string empresa = pedido.Substring(0, 2);
            string mistura = pedido.Substring(6, 2);
            PedidoDAO dao = new PedidoDAO();

            List<ModOfereceProduto> ped = dao.ListarPedido(pedido,empresa);

            ViewBag.empresa = empresa;
            ViewBag.cliente = cliente;
            ViewBag.mistura = mistura;

            return View(ped);

        }
        public ActionResult LocalEntrega(string cliente)
        {
            
          
            
            PedidoDAO dao = new PedidoDAO();

            List<ModCliente> cli = dao.LocalEntrega(cliente);
            return PartialView(cli);

        }
        public ActionResult SugestaoSobre(string mistura)
        {



            PedidoDAO dao = new PedidoDAO();

            List<ModItensPedidos> sug = dao.SugestaoSobre(mistura);
            return PartialView(sug);

        }
        public ActionResult SugestaoBebida(string mistura)
        {



            PedidoDAO dao = new PedidoDAO();

            List<ModItensPedidos> sug = dao.SugestaoBebida(mistura);
            return PartialView(sug);

        }


        public ActionResult FinalizarPedido()
        {
            string selecionado = Request.QueryString["item"];
            string cliente = Request.QueryString["cliente"];
            string endereco = Request.QueryString["endereco"];
            string numero = Request.QueryString["numero"];
            string valorUni = Request.QueryString["valor"];
            string pedido = null;
            string valor = null;

            pedido = selecionado.Replace(",", "");
            valor = valorUni.Replace(",", "");

            PedidoDAO dao = new PedidoDAO();

            string ao = dao.FinalizarPedido(pedido,cliente,endereco,numero,valor);


            ViewBag.nome = selecionado;
            ViewBag.nome2 = ao;
            ViewBag.cliente = cliente;
            return View();

        }

    }
}