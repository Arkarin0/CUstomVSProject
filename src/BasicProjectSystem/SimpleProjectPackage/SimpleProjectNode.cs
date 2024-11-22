using Microsoft.VisualStudio.Project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleProjectPackage
{
    public class SimpleProjectNode : ProjectNode
    {
        private readonly SimpleProjectPackage package;
        private static ImageList imageList;

        internal static int imageIndex;
        public override int ImageIndex
        {
            get { return imageIndex; }
        }

        static SimpleProjectNode()
        {
            imageList = Utilities.GetImageList(typeof(SimpleProjectNode).Assembly.GetManifestResourceStream("SimpleProjectPackage.Resources.SimpleProjectNode.bmp"));
        }

        public SimpleProjectNode(SimpleProjectPackage package) : base(package)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));

            imageIndex = this.ImageHandler.ImageList.Images.Count;

            foreach (Image img in imageList.Images)
            {
                this.ImageHandler.AddImage(img);
            }
        }

        public override Guid ProjectGuid => SimpleProjectPackage.SimpleProjectFactoryGuid;

        public override string ProjectType => "SimpleProjectType";

        public override void AddFileFromTemplate(string source, string target)
        {
            base.AddFileFromTemplate(source, target);
            this.FileTemplateProcessor.UntokenFile(source, target);
            this.FileTemplateProcessor.Reset();
        }
    }
}
