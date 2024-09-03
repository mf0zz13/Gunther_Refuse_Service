namespace GuntherRefuse.Views;

public partial class HomeView : ContentPage
{
    DispatchService ds = new();
    HomeViewModel _viewModel;
    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        ds.GetTodaysRecordsCount(_viewModel);
        base.OnAppearing();
    }

}


