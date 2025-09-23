using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using OpenSilver.WebAssembly;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenSilver.Samples.TelerikUI.Browser.Pages
{
    [Route("/")]
    public class Index : ComponentBase
    {
        [Inject]
        private LazyAssemblyLoader AssemblyLoader { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder __builder)
        {
        }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await Runner.RunApplicationAsync(() => new TelerikUI.App(new PrivateAssemblyLoader(AssemblyLoader)));
        }

        private sealed class PrivateAssemblyLoader : ILazyAssemblyLoader
        {
            private readonly LazyAssemblyLoader _assemblyLoader;

            public PrivateAssemblyLoader(LazyAssemblyLoader assemblyLoader)
            {
                _assemblyLoader = assemblyLoader;
            }

            public Task<IEnumerable<Assembly>> LoadAssembliesAsync(IEnumerable<string> assembliesToLoad) =>
                _assemblyLoader.LoadAssembliesAsync(assembliesToLoad);
        }
    }
}