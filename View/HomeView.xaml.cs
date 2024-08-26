namespace GuntherRefuse.View;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}