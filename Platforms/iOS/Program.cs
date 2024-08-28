using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using ObjCRuntime;
using UIKit;

namespace GuntherRefuse
{
    public class Program
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }

    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer()
        {

        }
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            return new CustomSectionRenderer(this);
        }
    }

    public class CustomSectionRenderer : ShellSectionRenderer
    {
        public CustomSectionRenderer(IShellContext context) : base(context)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InteractivePopGestureRecognizer.Enabled = false;
        }
    }
}
