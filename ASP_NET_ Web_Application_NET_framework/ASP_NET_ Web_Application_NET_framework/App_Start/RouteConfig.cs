using System.Web.Mvc;
using System.Web.Routing;

namespace ASP_NET__Web_Application_NET_framework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            /*=================================================================================*/
            /*    Criei a rota Novo usuario                                                         */
            /*=================================================================================*/



            /* "paginas/recupera/{id}", */
            routes.MapRoute(
                "paginas_recupera",
                "paginas/recupera/{id}",
                new { controller = "Paginas", action = "Recupera", id = 0 }
            );

            /*=================================================================================*/
            /*    Criei a rota Paginas                                                         */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas",
                "paginas",
                new { controller = "Paginas", action = "index" }
            );
            /*=================================================================================*/
            /*    Criei a rota Paginas                                                         */
            /*=================================================================================*/
            //
            //routes.MapRoute(
            //    "paginas2",
            ////    "paginas/{id}",
            //  new { controller = "Paginas", action = "index", id = "erroerroerroerroerroerro" }
            //);
            /*=================================================================================*/
            /*    Criei a rota Novo usuario                                                    */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas_novo",
                "paginas/novo",
                new { controller = "Paginas", action = "Novo" }
            );

            /*=================================================================================*/
            /*    Criei a rota Novo usuario    quando tem erro em campos                       */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas_altera",
                "paginas/altera",
                new { controller = "Paginas", action = "Altera" }
            );

            /*=================================================================================*/
            /*    Criei a rota Criar usuario               /paginas/signin                                          */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas_signin",
                "paginas/novo/index",
                new { controller = "Paginas", action = "Signin" }
            );



            /*=================================================================================*/
            /*    Criei a rota Criar usuario               /paginas/signin                                          */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas_criar",
                "paginas/novo/criar",
                new { controller = "Paginas", action = "Criar" }
            );

            /*=================================================================================*/
            /*    Criei a rota Criar usuario                                                         */
            /*=================================================================================*/

            routes.MapRoute(
                "paginas_recuperar",
                "paginas/novo/recupera",
                new { controller = "Paginas", action = "SaveRecupera" }
            );

            /*=================================================================================*/
            /*    Criei a rota Contato modificando para português                              */
            /*=================================================================================*/

            routes.MapRoute(
                "contato",
                "contato",
                new { controller = "Home", action = "contact" }
            );

            /*=================================================================================*/
            /*    Criei a rota Consulta modificando para portugês                               */
            /*=================================================================================*/

            routes.MapRoute(
                "consulta",
                "consulta/{id}/Eduardo",
                new { controller = "Home", action = "contact", id = 0 }
            );
            /*=================================================================================*/
            /* Esta é a rota padrão, deve sempre ficar por último, pois as rota não redefindas */
            /* caem na rota padrão e serão executadas.                                         */
            /*=================================================================================*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
