using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using System;

namespace SimpleProjectPackage
{
    [Guid(SimpleProjectPackage.SimpleProjectFactoryString)]
    internal class SimpleProjectFactory : ProjectFactory
    {
        private readonly SimpleProjectPackage package;

        public SimpleProjectFactory(SimpleProjectPackage package) : base(package)
        {
            this.package = package;
        }

        protected override ProjectNode CreateProject()
        {
            var project = new SimpleProjectNode(package);

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            project.SetSite((IOleServiceProvider)((IServiceProvider)this.package).GetService(typeof(IOleServiceProvider)));

            return project;
        }
    }
}
