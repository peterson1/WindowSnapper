using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos9 : SnapWindowCommandBase
    {
        private SnapWindowToPos9(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(9, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos9(4, 0, pkg, await pkg.GetMenuService());
    }
}
