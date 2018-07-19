using CommonTools.Lib11.ExceptionTools;
using CommonTools.Lib11.StringTools;
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
        private int          _screenIdx;


        public SnapWindowCommandBase(int commandId, int positionKey, int displayIndex, AsyncPackage vsPackage, OleMenuCommandService commandSvc)
        {
            _posKey    = positionKey;
            _screenIdx = displayIndex;
            _vsPkg     = vsPackage  ?? throw new ArgumentNullException(nameof(vsPackage));
            commandSvc = commandSvc ?? throw new ArgumentNullException(nameof(commandSvc));
            commandSvc.AddCommand(CreateMenuCommand(commandId));

        }


        private OleMenuCommand CreateMenuCommand(int commandId)
        {
            var menuCmdID = new CommandID(new Guid(CMDSET_GUID), commandId);
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

            bool ok = false;
            try
            {
                ok = win.SnapToPosition(_posKey, _screenIdx);
            }
            catch (Exception ex)
            {
                Alert(ex.Info(true, true));
            }

            if (!ok) Alert($"Invalid parameters."
                    + $"{L.F}Position key: [{_posKey}]"
                    + $"{L.f}Display index: [{_screenIdx}]");
        }


        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            if ((sender is OleMenuCommand cmd))
                cmd.Text = $"Snap Window to Position [{_posKey}]";
        }


        private void Alert(string message) => VsShellUtilities.ShowMessageBox(
                this._vsPkg,
                message,
                $"Snap to Window Position [{_posKey}]",
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
    }
}
