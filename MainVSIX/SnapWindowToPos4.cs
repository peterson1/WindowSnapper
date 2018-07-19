using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos4 : SnapWindowCommandBase
    {
        private SnapWindowToPos4(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(4, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos4(4, 1, pkg, await pkg.GetMenuService());
    }
}
