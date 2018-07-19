using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos3 : SnapWindowCommandBase
    {
        private SnapWindowToPos3(int positionKey, AsyncPackage package, OleMenuCommandService commandService)
            : base(positionKey, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos3(3, pkg, await pkg.GetMenuService());
    }
}
