namespace GuntherRefuse.Views;

public partial class DispatchView : ContentPage
{
	DispatchViewModel dvm;
	public DispatchView(DispatchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.dvm = viewModel;
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value)
			dvm.IsChecked = true;
		else
			dvm.IsChecked = false;

	
    }
}