using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos6 : SnapWindowCommandBase
    {
        private SnapWindowToPos6(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(6, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos6(1, 0, pkg, await pkg.GetMenuService());
    }
}
