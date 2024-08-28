namespace GuntherRefuse.Views;

public partial class DispatchView : ContentPage
{
	public DispatchView(DispatchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}