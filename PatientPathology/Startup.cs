using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientPathology.Startup))]
namespace PatientPathology
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
