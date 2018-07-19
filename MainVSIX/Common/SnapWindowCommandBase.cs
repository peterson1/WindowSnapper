using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace MainVSIX.Common
{
    internal class SnapWindowCommandBase
    {
        public const string CMDSET_GUID = "d2773343-8dc8-4530-8d11-0ce92a2d31ec";
        private AsyncPackage _vsPkg;
        private int          _posKey;


        public SnapWindowCommandBase(int positionKey, AsyncPackage vsPackage, OleMenuCommandService commandSvc)
        {
            _posKey    = positionKey;
            _vsPkg     = vsPackage  ?? throw new ArgumentNullException(nameof(vsPackage));
            commandSvc = commandSvc ?? throw new ArgumentNullException(nameof(commandSvc));
            commandSvc.AddCommand(CreateMenuCommand());

        }


        private OleMenuCommand CreateMenuCommand()
        {
            var menuCmdID = new CommandID(new Guid(CMDSET_GUID), _posKey);
            var menuItem  = new OleMenuCommand(this.Execute, menuCmdID);
            menuItem.BeforeQueryStatus += new EventHandler(OnBeforeQueryStatus);
            return menuItem;
        }


        protected async Task<OleMenuCommandService> GetMenuService()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var svc = await _vsPkg.GetServiceAsync((typeof(IMenuCommandService)));
            return svc as OleMenuCommandService;
        }



        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

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

            //win.IsFloating = true;
            //win.Left = _posKey * 300;
            //win.Top = -1080;
            win.SnapToPosition(_posKey, 1);
        }


        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            if ((sender is OleMenuCommand cmd))
                cmd.Text = $"Snap Window to Position [{_posKey}]";
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
