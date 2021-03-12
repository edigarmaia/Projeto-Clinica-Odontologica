using projetoLoginOdontologia.Dados;
using projetoLoginOdontologia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projetoLoginOdontologia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //intanciando o método para testar usuario
        acoesLogin acLg = new acoesLogin();

        //criando uma nova index para o login
        [HttpPost]
        public ActionResult Index(modelLogin verLogin)
        {
            acLg.TestarUsuario(verLogin);

            if (verLogin.usuario != null && verLogin.senha != null)
            {
                //criando a auteticação da sessao dentro do login
                FormsAuthentication.SetAuthCookie(verLogin.usuario, false);
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();


                //verificadando o tipo de usuario
                if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString(); //=1;
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();//=2
                }

                //pagina para onde sera direcionado o usuario logado
                return RedirectToAction("About", "Home");
            }

            else
            {

                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                Response.Write("<script>alert('Erro no Login')</script>");
                return View();

            }
        }

        public ActionResult About()
        {

            if((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                TempData["Message"] = "Acesso Negado. Utilize um login e senha válidos";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

        }

        public ActionResult Contact()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                TempData["Message"] = "Acesso Negado. Utilize um login e senha válidos";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Permitindo acesso somente de um tipo de usuario (tipo2)
                if (Session["tipoLogado2"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                else
                {
                    return View();
                }

            }

        }
        //Encerrando a sessão do usuario logado
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null; TempData["Message"] = "Logout realizado com sucesso!";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult semAcesso()
        {
            ViewBag.Message = "Você não pode acessar essa página";

            return View();
        }
    }
}