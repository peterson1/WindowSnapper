using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos0 : SnapWindowCommandBase
    {
        private SnapWindowToPos0(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(10, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos0(5, 0, pkg, await pkg.GetMenuService());
    }
}
