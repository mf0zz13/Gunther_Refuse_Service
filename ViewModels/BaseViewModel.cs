namespace GuntherRefuse.ViewModels;

public partial class BaseViewModel : ObservableObject
{
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsNotBusy))]
	private bool isBusy;

	public bool IsNotBusy => !IsBusy;

	[ObservableProperty]
	string title;
}