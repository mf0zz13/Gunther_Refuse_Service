using System.Text.RegularExpressions;

namespace GuntherRefuse
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }

        private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (IsValidEmail(EmailEntry.Text)) { }
            else
            {
                EmailEntry.TextColor = Colors.Red;
                EmailErrorLabel.Text = "Not a valid email";


            }
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #region Sign in Button Methods
        private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
        {
            Button button = (Button)sender;
            button.BorderColor = Colors.Black;
            button.BorderWidth = 5;
        }

        private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
        {
            Button button = (Button)sender;
            button.BorderColor = Colors.Transparent;
            button.BorderWidth = 0;
        }

        private void SignInButton_Pressed(object sender, EventArgs e)
        {

        }

        private void SignInButton_Released(object sender, EventArgs e)
        {

        }
        #endregion

        #region Validation Methods
        private bool IsValidEmail(string email)
        {
            //string pattern = @"^[A-Z,a-z,.,0-9]{1,25}[@gutherrefuse.com]";
            //Match match = Regex.Match(email, pattern);
            //if (match.Success) { return true; }

            return false;
        }
        #endregion

        private void EmailEntry_Focused(object sender, FocusEventArgs e)
        {
            EmailEntry.TextColor = Colors.Black;
            EmailErrorLabel.Text = "";
        }
    }
}
