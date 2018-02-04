namespace Local.Rest.ApiRest
{
    using Owin;
    using System.Web.Http;
    using App_Start;
    using System.Configuration;
    using log4net;

    /// <summary>
    /// Represents the entry point into an application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Specifies how the ASP.NET application will respond to individual HTTP request.
        /// </summary>
        /// <param name="app">Instance of <see cref="IAppBuilder"/>.</param>
        public void Configuration(IAppBuilder app)
        {
            LogConfig.Configure();
            
            //app.UseRequestLogging();

            CorsConfig.ConfigureCors(ConfigurationManager.AppSettings["cors"]);
            app.UseCors(CorsConfig.Options);

            HttpConfiguration configuration = new HttpConfiguration();

            FormatterConfig.Configure(configuration);
            RouteConfig.Configure(configuration);
            ServiceConfig.Configure(configuration);
            SwaggerConfig.Configure(configuration);

            app.UseWebApi(configuration);
        }
    }
}
