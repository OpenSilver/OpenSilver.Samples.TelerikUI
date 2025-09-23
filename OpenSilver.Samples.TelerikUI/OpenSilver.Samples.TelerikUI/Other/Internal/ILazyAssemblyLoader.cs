using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenSilver.Samples.TelerikUI
{
    public interface ILazyAssemblyLoader
    {
        Task<IEnumerable<Assembly>> LoadAssembliesAsync(IEnumerable<string> assembliesToLoad);
    }
}
