namespace GuntherRefuse
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DispatchTrucksView), typeof(DispatchTrucksView));
            Routing.RegisterRoute(nameof(ManageEmployeesView), typeof(ManageEmployeesView));
            Routing.RegisterRoute(nameof(DispatchView), typeof(DispatchView));
        }
    }
}
