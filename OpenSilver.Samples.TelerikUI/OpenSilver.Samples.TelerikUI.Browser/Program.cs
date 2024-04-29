using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace OpenSilver.Samples.TelerikUI.Browser
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var host = builder.Build();
            await host.RunAsync();
        }
    }
}