using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos9 : SnapWindowCommandBase
    {
        private SnapWindowToPos9(int positionKey, AsyncPackage package, OleMenuCommandService commandService)
            : base(positionKey, package, commandService)
        {
        }


        public static SnapWindowCommandBase Instance { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos9(9, pkg, await pkg.GetMenuService());
    }
}
