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

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
                dvm.IsChecked = true;
            else
                dvm.IsChecked = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            dv.driverSearchBar.HideKeyboardAsync(CancellationToken.None);
            dv.driverSearchBar.Text = "";
            dv.driverNameLabel.Text = dvm.DispatchDriver.FullName;
            dvm.filteredEmployeeList.Clear();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            dv.helperOneSearchBar.HideKeyboardAsync(CancellationToken.None);
            dv.helperOneSearchBar.Text = "";
            dv.HelperOneNameLabel.Text = dvm.HelperOne.FullName;
            dvm.filteredEmployeeList1.Clear();
        }

        private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            dv.helperTwoSearchBar.HideKeyboardAsync(CancellationToken.None);
            dv.helperTwoSearchBar.Text = "";
            dv.helperTwoNameLabel.Text = dvm.HelperTwo.FullName;
            dvm.filteredEmployeeList2.Clear();
        }

        private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            dv.helperThreeSearchBar.HideKeyboardAsync(CancellationToken.None);
            dv.helperThreeSearchBar.Text = "";
            dv.helperThreeNameLabel.Text = dvm.HelperThree.FullName;
            dvm.filteredEmployeeList3.Clear();
        }
    }
}