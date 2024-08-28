namespace GuntherRefuse.Views;

public partial class DispatchTrucksView : ContentPage
{
	public DispatchTrucksView(DispatchTrucksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}