namespace GuntherRefuse.ViewModels
{
    [QueryProperty(nameof(Truck), nameof(Truck))]
    public partial class DispatchViewModel : BaseViewModel
    {
        [ObservableProperty]
        Truck truck;

        public DispatchViewModel()
        {
        }
    }
}
