namespace GuntherRefuse.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    public async void Initalize(HomeViewModel viewModel)
    {
        await viewModel.GetNumberOfTrucks();
    }
}


