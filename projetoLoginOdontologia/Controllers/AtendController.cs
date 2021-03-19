using MySql.Data.MySqlClient;
using projetoLoginOdontologia.Dados;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoLoginOdontologia.Controllers
{
    public class AtendController : Controller
    {
        // GET: Atendimento
        public ActionResult Index()
        {
            return View();
        }

        acoesAtendimento ac = new acoesAtendimento();

        public void carregaPacientes()
        {
            List<SelectListItem> ag = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdClinOdonto;User=root;pwd=Nova100@"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbPaciente order by nomePac;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ag.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.paciente = new SelectList(ag, "Value", "Text");
        }


        public void carregaDentistas()
        {
            List<SelectListItem> dent = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=bdClinOdonto;User=root;pwd=Nova100@"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbDentista order by nomeDentista;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dent.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.dentista = new SelectList(dent, "Value", "Text");
        }



        public ActionResult cadAtendimento()
        {
            carregaDentistas();
            carregaPacientes();
            return View();
        }


        [HttpPost]
        public ActionResult cadAtendimento(modelAtendimento at)
        {
            carregaDentistas();
            carregaPacientes();
            at.codPac = Request["paciente"];
            at.codDentista = Request["dentista"];
            ac.TestarAgenda(at);

            if (at.confAgendamento == "1")
            {
                ac.inserirAtendimento(at);
                ViewBag.msg = "Agendamento Realizado";
                return View();
            }
            else if (at.confAgendamento == "0")
            {
                ViewBag.msg = "Horário indisponível";
                return View();
            }

            return View();

        }



    }
}