namespace Local.Rest.ApiRest.App_Start
{
    using Swashbuckle.Application;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using System.Net.Http;

    /// <summary>
    /// Represents configuration for Swagger and SwaggerUI
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Configures Swagger and SwaggerUI.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);

            configuration.EnableSwagger("docs/{apiVersion}/OpenAPI", c =>
            {
                //Tell swagger to generate documentation based on the XML doc file output from msbuild
                c.IncludeXmlComments(Path.Combine(baseDirectory, "bin", "Local.Rest.ApiRest.XML"));
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.SingleApiVersion("1.0", "Documentacion Prueba")
                    // El titulo debe venir de algun tipo de configuración
                    .Description("API de la aplicación Prueba Restauracion")
                    .Contact(cc => cc
                        .Name("Luis Rodriguez"));
                        //.Url("")
                        //.Email(""));
                c.PrettyPrint();
                c.RootUrl(req => req.RequestUri.GetLeftPart(UriPartial.Authority) + req.GetRequestContext().VirtualPathRoot.TrimEnd('/'));
            }).EnableSwaggerUi("docs/{*assetPath}", c =>
                {

                    //c.InjectStylesheet(typeof(SwaggerUI.Assets.Class1).Assembly, "SwaggerUI.Assets.css");
                }
            );

        }
    }
}