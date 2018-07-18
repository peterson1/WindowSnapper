using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace MainVSIX.Common
{
    public static class AsyncPackageExtensions
    {
        public static async Task<TConcrete> FindService<TInterface, TConcrete>(this AsyncPackage vsPackage)
            where TConcrete : class
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var svc = await vsPackage.GetServiceAsync((typeof(TInterface)));

            if (svc is TConcrete concrete)
                return concrete;
            else
                throw new InvalidCastException(
                    $"Failed to cast ‹{typeof(TInterface).Name}› to ‹{typeof(TConcrete).Name}›.");
        }


        public static Task<OleMenuCommandService> GetMenuService(this AsyncPackage vsPackage)
            => vsPackage.FindService<IMenuCommandService, OleMenuCommandService>();
    }
}
