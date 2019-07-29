using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRentalMVCApplication.Startup))]
namespace MovieRentalMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
