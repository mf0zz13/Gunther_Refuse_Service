using System.Collections;

namespace GuntherRefuse.ViewModel;

[QueryProperty(nameof(Dispatch), nameof(Dispatch))]
public partial class DispatchViewModel : BaseViewModel
{
	Dispatch dispatchRecord;

	public List<string> CollectionTypes = new() { "Select One", "Trash", "Recycling", "Yard Waste" };

    [ObservableProperty]
	Dispatch dispatch;


	
	public DispatchViewModel()
	{
    }
}