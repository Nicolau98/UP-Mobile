using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(UP_Mobile.Areas.Identity.IdentityHostingStartup))]
namespace UP_Mobile.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}