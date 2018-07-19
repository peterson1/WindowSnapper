using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos1 : SnapWindowCommandBase
    {
        private SnapWindowToPos1(int positionKey, int displayIndex, AsyncPackage package, OleMenuCommandService commandService) 
            : base(1, positionKey, displayIndex, package, commandService)
        {
        }


        public static SnapWindowCommandBase   Instance   { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos1(1, 1, pkg, await pkg.GetMenuService());
    }
}
