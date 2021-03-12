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
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        acoesPaciente acPac = new acoesPaciente();


        public ActionResult cadPaciente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult cadPaciente(modelPaciente pac)
        {
            acPac.inserirPaciente(pac);

            ViewBag.confCadastro = "Cadastro Realizado com sucesso";
            return View();
        }



        public ActionResult consPaciente()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acPac.consultaPaciente(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }




        public ActionResult buscaPaciente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult buscaPaciente(modelPaciente pac)
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acPac.buscaPaciente(pac); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }


        public ActionResult selecionaPaciente()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acPac.consultaPaciente(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }




        public static string cod;

        public ActionResult AtualizaPaciente(modelPaciente pac)
        {
            acPac.consultaBuscaPaciente(pac);
            cod = pac.CodPac;
            ViewBag.nome = pac.NomePac;
            ViewBag.tel = pac.Telpac;
            return View();
        }

        [HttpPost]
        public ActionResult confAtualizaPaciente(modelPaciente pac)
        {
            pac.CodPac = cod;
            acPac.atualizarPaciente(pac);
            return View();
        }



        public ActionResult selecionaPacienteExcluir()
        {
            GridView dgv = new GridView(); // Instância para a tabela
            dgv.DataSource = acPac.consultaPaciente(); //Atribuir ao grid o resultado da consulta
            dgv.DataBind(); //Confirmação do Grid
            StringWriter sw = new StringWriter(); //Comando para construção do Grid na tela
            HtmlTextWriter htw = new HtmlTextWriter(sw); //Comando para construção do Grid na tela
            dgv.RenderControl(htw); //Comando para construção do Grid na tela
            ViewBag.GridViewString = sw.ToString(); //Comando para construção do Grid na tela
            return View();
        }






        public ActionResult excluirPaciente(modelPaciente pac)
        {
            acPac.consultaBuscaPaciente(pac);
            cod = pac.CodPac;
            ViewBag.codigo = cod;
            ViewBag.nome = pac.NomePac;
            ViewBag.tel = pac.Telpac;
            return View();
        }



        [HttpPost]
        public ActionResult confExcluirPaciente(modelPaciente pac)
        {
            pac.CodPac = cod;
            acPac.excluirPaciente(pac);
            return View();
        }

        public ActionResult cadPacienteFoto()
        {
            return View();
        }
    }
}