using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using Task = System.Threading.Tasks.Task;


namespace MainVSIX
{
    internal sealed class SnapWindowLeftCmd
    {
        public static readonly Guid      CommandSet = new Guid("d2773343-8dc8-4530-8d11-0ce92a2d31ec");
        public const  int                CommandId  = 0x0100;
        public static SnapWindowLeftCmd  Instance   { get; private set; }

        private       readonly AsyncPackage _vsPkg;
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider => _vsPkg;


        private SnapWindowLeftCmd(AsyncPackage vsPackage, OleMenuCommandService commandSvc)
        {
            this._vsPkg   = vsPackage  ?? throw new ArgumentNullException(nameof(vsPackage));
            commandSvc    = commandSvc ?? throw new ArgumentNullException(nameof(commandSvc));
            var menuCmdID = new CommandID(CommandSet, CommandId);
            //var menuItem  = new MenuCommand(this.Execute, menuCmdID);
            var menuItem  = new OleMenuCommand(this.Execute, menuCmdID);
            menuItem.BeforeQueryStatus += new EventHandler(OnBeforeQueryStatus);
            commandSvc.AddCommand(menuItem);
        }


        public static async Task InitializeAsync(AsyncPackage package)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new SnapWindowLeftCmd(package, commandService);
        }


        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            if (!(sender is OleMenuCommand cmd)) return;
            cmd.Text = "On Before Query Status!!!";
        }


        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            //var win = _vsPkg.

            //var dte = await _vsPkg.GetServiceAsync(typeof(EnvDTE80.DTE2)) as EnvDTE80.DTE2;
            //var nme = dte.ActiveDocument.Name;

            var dte2 = ((IServiceProvider)_vsPkg).GetService(typeof(SDTE)) as EnvDTE80.DTE2;
            var doc = dte2.ActiveDocument;
            if (doc == null)
            {
                Alert("No active document");
                return;
            }

            var win = doc.ActiveWindow;
            if (win == null)
            {
                Alert("No active window");
                return;
            }

            win.IsFloating = true;
            win.Left = 0;
            win.Top = -1000;

            //actv.ActiveWindow.IsFloating = true;
            //actv.ActiveWindow.


            //var msg = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName);

            //// Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this._vsPkg,
            //    msg,
            //    "SnapWindowLeftCmd",
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }


        private void Alert(string msg) => VsShellUtilities.ShowMessageBox(
                this._vsPkg,
                msg,
                "SnapWindowLeftCmd",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
    }
}
