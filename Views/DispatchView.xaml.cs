namespace GuntherRefuse.Views
{
    public partial class DispatchView : ContentPage
    {
        DispatchViewModel dvm;
        Entry entry;
        public DispatchView(DispatchViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.dvm = viewModel;
            this.entry = new();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
                dvm.IsChecked = true;
            else
                dvm.IsChecked = false;
        }

        private void driverSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            entry.HideKeyboardAsync(CancellationToken.None);
        }
    }
}