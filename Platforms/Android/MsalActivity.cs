using Android.App;
using Microsoft.Identity.Client;
using Android.Content;

namespace GuntherRefuse.Platforms.Android
{
    [Activity(Exported = true)]
    [IntentFilter(new[] {Intent.ActionView},
        Categories = new[] {Intent.CategoryBrowsable, Intent.CategoryDefault},
        DataHost = "auth",
        DataScheme = "msaleb42cd1a-683e-43af-a7a0-b44a4f2e5bd7")]
    internal class MsalActivity : BrowserTabActivity
    {
    }
}
