namespace GuntherRefuse.Views
{
    public partial class DispatchView : ContentPage
    {
        DispatchViewModel dvm;
        DispatchView dv;
        public DispatchView(DispatchViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.dvm = viewModel;
            dv = this;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            dv.driverSearchBar.Text = "";
            dv.driverNameLabel.Text = dvm.DispatchDriver.FullName;
            dvm.filteredEmployeeList.Clear();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            dv.helperOneSearchBar.Text = "";
            dv.HelperOneNameLabel.Text = dvm.HelperOne.FullName;
            dvm.filteredEmployeeList1.Clear();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            dv.helperTwoSearchBar.Text = "";
            dv.helperTwoNameLabel.Text = dvm.HelperTwo.FullName;
            dvm.filteredEmployeeList2.Clear();
        }

        private void helperTwoSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            dv.helperTwoSearchBar.HideKeyboardAsync(CancellationToken.None);
        }

        private void helperOneSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            dv.helperOneSearchBar.HideKeyboardAsync(CancellationToken.None);
        }

        private void driverSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            dv.driverSearchBar.HideKeyboardAsync(CancellationToken.None);
        }
    }
}