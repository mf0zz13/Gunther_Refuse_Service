namespace GuntherRefuse.View;

public partial class DispatchTrucksView : ContentPage
{
	public DispatchTrucksView(DispatchTrucksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}