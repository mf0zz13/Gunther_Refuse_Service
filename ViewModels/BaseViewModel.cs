namespace GuntherRefuse.ViewModels
{

	public partial class BaseViewModel : ObservableObject
	{
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		public bool IsNotBusy => !IsBusy;

		[ObservableProperty]
		string title;

		[ObservableProperty]
		bool refreshing;

		[RelayCommand]
		public void Refreshed()
		{
			Refreshing = false;
		}

		[RelayCommand]
		public void RefreshView()
		{
			Refreshing = true;
		}
	}
}