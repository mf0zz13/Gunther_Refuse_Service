namespace GuntherRefuse
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(DispatchView), typeof(DispatchView));
        }
    }
}
