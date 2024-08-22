namespace GuntherRefuse.View;

public partial class DispatcherView : ContentPage
{
	public DispatcherView(DispatcherViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}