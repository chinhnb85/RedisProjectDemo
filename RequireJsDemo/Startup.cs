using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RequireJsDemo.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]
namespace RequireJsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}