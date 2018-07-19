using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos8 : SnapWindowCommandBase
    {
        private SnapWindowToPos8(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(8, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos8(3, 0, pkg, await pkg.GetMenuService());
    }
}
