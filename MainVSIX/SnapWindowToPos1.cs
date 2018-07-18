using MainVSIX.Common;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace MainVSIX
{
    internal sealed class SnapWindowToPos1 : SnapWindowToPosBase
    {
        private SnapWindowToPos1(int positionKey, AsyncPackage package, OleMenuCommandService commandService) 
            : base(positionKey, package, commandService)
        {
        }


        public static SnapWindowToPosBase   Instance   { get; private set; }


        public static async Task InitializeAsync(AsyncPackage pkg)
            => Instance = new SnapWindowToPos1(1, pkg, await pkg.GetMenuService());
    }
}
