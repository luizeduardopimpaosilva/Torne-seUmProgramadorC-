using Business;
using System;
using System.Web.Mvc;

namespace ASP_NET__Web_Application_NET_framework.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            // ViewBag.Paginas = new PaginaSignin().Lista();

            return View();
        }

        public ActionResult Novo()
        {
            /* if (Request["person_name"] == null) 
            { 
            
            var pagina = new PaginaSignin();

            pagina.person_name = "teste ";

            pagina.person_email_address = " tetste";

            pagina.person_key = " testest";

            pagina.person_password = "setsetsets ";

            pagina.person_password_confirm = "stetse ";

            pagina.person_password_confirm = "stestes ";
            */
            if(ViewBag.Pagina == null)
            {
                var pagina = new PaginaSignin();
                ViewBag.Pagina = pagina;
            }
            
           
            return View();
        }

        public ActionResult Recupera(int id) // recebe como parâmetro o id
        {
            return View();
        }
        public ActionResult Altera()
        {
            //ViewBag.Paginas = new PaginaSignin().Lista();

            return View();
        }

        /*=====================================================================================================*/
        /* Esta rotina trata o email ou cahve de acesso para fazer Sig in no sistema                           */
        /*=====================================================================================================*/

        [HttpPost]
        public void Signin()
        {
            try
            {
                var pagina = new PaginaSignin();


                pagina.person_email_address = Request["person_email_address"];
                pagina.person_date_update = DateTime.Now;

                bool recuperaOk = false;

                pagina.SaveRecupera(recuperaOk, pagina.person_email);

                if (recuperaOk)
                {
                    TempData["Sucesso"] = "Check your email inbox to complete your password change.";
                    ViewBag.Sucesso = "Check your email inbox to complete your password change.";
                    TempData.Keep("Sucesso");
                }
                else
                {
                    TempData["Erro"] = "The email address you entered was not found.";
                    ViewBag.Erro = "The email address you entered was not found.";
                    TempData.Keep("Erro");
                }

            }
            catch
            {
                TempData["Errosql"] = "There was an error in your request(SQL error -400 ).";
            }

            Response.Redirect("/paginas");
        }


        /*=====================================================================================================*/
        /* Esta rotina trata o email informado para recuperação de password.                                   */
        /*=====================================================================================================*/

        [HttpPost]
        public void Email()
        {
            string mens1 = "Mensagem de testes Email";
            ViewData["Teste"] = mens1;

            try
            {
                var pagina = new PaginaSignin();
                                
                pagina.person_email_address = Request["person_email_address"];
                pagina.person_date_update = DateTime.Now;

                bool recuperaOk = false;

                recuperaOk = pagina.SaveRecupera(recuperaOk, pagina.person_email_address);


                if (recuperaOk)
                {
                    TempData["Sucesso"] = "Check your email inbox to complete your password change.";
                    ViewBag.Sucesso = "Check your email inbox to complete your password change.";
                }
                else
                {
                    string errotemp = "The email address you entered was not found.";
                    TempData["Erro"] = errotemp;
                    ViewBag.Erro = "viewBag The email address you entered was not found.";

                }

            }
            catch
            {
                TempData["Errosql"] = "There was an error in your request(SQL error -400 ).";
            }

            Response.Redirect("/paginas");
        }

        [HttpPost]
        public void Criar()
        {
            var caminho = "/paginas/index";

            var pagina = new PaginaSignin();
            // ViewBag.Paginas = new PaginaSignin().Lista();
            pagina.person_name = Request["person_name"];

            pagina.person_email_address = Request["person_email_address"];

            pagina.person_key = Request["person_key"];

            pagina.person_password = Request["person_password"];

            pagina.person_password_confirm = Request["person_password_confirm"];

            DateTime data = DateTime.Now;

            pagina.person_password_confirm = Request["person_password_confirm"];

            /*   Valida INEXISTËNCIA de mesma Key e Email na tabela Persons    */
            
            ViewBag.Pagina = pagina;

            try
            {
                //     Busca Por Email           

                var pagina2 = new PaginaSignin();
                pagina2 = pagina.BuscaPorEmail(pagina.person_email_address);

                if (pagina2.person_email_address != null)
                {
                    TempData["Erro"] = "The email informed already exists.";
                    ViewBag.Erro = "The email informed already exists.";
                    ViewBag.Pagina = pagina;
                    caminho = "/Paginas/Novo";
                }
                else
                {
                    try
                    {
                        //      Busca Por Key

                        pagina2 = pagina.BuscaPorKey(pagina.person_key);


                        if (pagina2.person_key != null)
                        {
                            TempData["Erro"] = "The User Key informed already exists.";
                            ViewBag.Erro = "The User Key informed already exists.";
                            ViewBag["Pagina"] = pagina;
                            caminho = "/Paginas/Novo";
                        }
                        else
                        {
                            pagina.Save();
                        }
                    }
                    catch
                    {
                        TempData["Errosql"] = "There was an error in your request(SQL error -400 ).";
                    }
                }
            }
            catch
            {
                TempData["Errosql"] = "There was an error in your request(SQL error -400 ).";
            }           

            Response.Redirect(caminho);
        }

    }
}