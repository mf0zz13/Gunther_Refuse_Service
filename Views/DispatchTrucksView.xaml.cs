namespace GuntherRefuse.Views;

public partial class DispatchTrucksView : ContentPage
{
    DispatchTrucksViewModel _viewModel;
    public DispatchTrucksView(DispatchTrucksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        _viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        _viewModel.GetAvalibleTrucks();
        base.OnAppearing();
    }
}