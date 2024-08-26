namespace GuntherRefuse.View;

public partial class EmployeeView : ContentPage
{
	public EmployeeView(EmployeeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}