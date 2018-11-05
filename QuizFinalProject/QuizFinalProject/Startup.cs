using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizFinalProject.Startup))]
namespace QuizFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
