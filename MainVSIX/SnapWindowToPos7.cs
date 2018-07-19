using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos7 : SnapWindowCommandBase
    {
        private SnapWindowToPos7(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(7, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos7(2, 0, pkg, await pkg.GetMenuService());
    }
}
