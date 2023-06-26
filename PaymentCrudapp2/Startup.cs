using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaymentCrudapp2.Startup))]
namespace PaymentCrudapp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
