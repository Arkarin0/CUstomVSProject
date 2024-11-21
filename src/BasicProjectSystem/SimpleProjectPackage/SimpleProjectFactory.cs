using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Project;

namespace SimpleProjectPackage
{
    [Guid(SimpleProjectPackage.SimpleProjectFactoryString)]
    internal class SimpleProjectFactory : ProjectFactory
    {
        private readonly Package package;

        public SimpleProjectFactory(Package package) : base(package)
        {
            this.package = package;
        }

        protected override ProjectNode CreateProject()
        {
            return null;
        }
    }
}
