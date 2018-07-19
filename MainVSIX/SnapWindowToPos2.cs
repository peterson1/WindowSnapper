using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos2 : SnapWindowCommandBase
    {
        private SnapWindowToPos2(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService)
            : base(2, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase   Instance   { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos2(2, 1, pkg, await pkg.GetMenuService());
    }
}
