using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos3 : SnapWindowCommandBase
    {
        private SnapWindowToPos3(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(3, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos3(3, 1, pkg, await pkg.GetMenuService());
    }
}
