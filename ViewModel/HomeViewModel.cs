namespace GuntherRefuse.ViewModel;

public partial class HomeViewModel : BaseViewModel
{
    DispatchStatusService dispatchStatusService = new();

    public ObservableCollection<Dispatch> DispatchStatus { get; } = new();


    public HomeViewModel(DispatchStatusService dispatchStatusService)
    {
        this.dispatchStatusService = dispatchStatusService;
        this.GetDispatchStatus();
    }

    [RelayCommand]
    public async void GetDispatchStatus()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            List<Dispatch> dispatchStatusList = await dispatchStatusService.GetDispatchStatus();

            foreach (Dispatch record in dispatchStatusList)
            {
                DispatchStatus.Add(record);
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoToDispatchRecord(Dispatch dispatch)
    {
        if (dispatch is null)
            return;

        await Shell.Current.GoToAsync(nameof(DispatchView), true, new Dictionary<string, object>
        {
            {nameof(Dispatch),  dispatch}
        });
    }
}