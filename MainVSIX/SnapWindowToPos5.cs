using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos5 : SnapWindowCommandBase
    {
        private SnapWindowToPos5(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(5, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos5(5, 1, pkg, await pkg.GetMenuService());
    }
}
