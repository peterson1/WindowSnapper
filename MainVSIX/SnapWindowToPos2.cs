using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos2 : SnapWindowCommandBase
    {
        private SnapWindowToPos2(int positionKey, AsyncPackage package, OleMenuCommandService commandService)
            : base(positionKey, package, commandService)
        {
        }


        public static SnapWindowCommandBase   Instance   { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos2(2, pkg, await pkg.GetMenuService());
    }
}
