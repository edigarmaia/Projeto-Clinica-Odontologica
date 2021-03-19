using projetoLoginOdontologia.Dados;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoLoginOdontologia.Controllers
{
    public class DentistaController : Controller
    {
        // GET: Dentista
        public ActionResult Index()
        {
            return View();
        }
        //cadastrando o dentista
        acoesDentista acDent = new acoesDentista();


        public ActionResult cadDentista()
        {
            return View();
        }


        [HttpPost]
        public ActionResult cadDentista(modelDentista dent)
        {
            acDent.inserirDentista(dent);

            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }
        //consultando o dentista
        public ActionResult consDentista()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acDent.consultaDentista(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }

        public ActionResult buscaDentista()
        {
            return View();
        }

        [HttpPost]
        public ActionResult buscaDentista(modelDentista dent)
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acDent.buscaDentista(dent); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }

        //atualizando o dentista
            public ActionResult selecionaDentista()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acDent.consultaDentista(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }

        public static string cod;

        public ActionResult AtualizaDentista(modelDentista dent)
        {
            acDent.consultaBuscaDentista(dent);
            cod = dent.CodDentista;
            ViewBag.nome = dent.NomeDentista;
            ViewBag.tel = dent.TelDentista;
            ViewBag.email = dent.EmailDentista;
            return View();
        }

        [HttpPost]
        public ActionResult confAtualizaDentista(modelDentista dent)
        {
            dent.CodDentista = cod;
            acDent.atualizarDentista(dent);
            return View();
        }

        //excluindo o dentista
        public ActionResult selecionaDentistaExcluir()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acDent.consultaDentista(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }


        public ActionResult excluirDentista(modelDentista dent)
        {
            acDent.consultaBuscaDentista(dent);
            cod = dent.CodDentista;
            ViewBag.codigo = cod;
            ViewBag.nome = dent.NomeDentista;
            ViewBag.tel = dent.TelDentista;
            ViewBag.email = dent.EmailDentista;
            return View();
        }

        [HttpPost]
        public ActionResult confExcluirDentista(modelDentista dent)
        {
            dent.CodDentista = cod;
            acDent.excluirDentista(dent);
            return View();
        }

        public ActionResult cadDentistaFoto()
        {
            return View();
        }

        

    }
}