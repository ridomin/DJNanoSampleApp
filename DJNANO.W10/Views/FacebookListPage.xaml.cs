using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Facebook;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class FacebookListPage : PageBase
    {
        public FacebookListPage()
        {
            this.ViewModel = new ListViewModel<FacebookDataConfig, FacebookSchema>(new FacebookConfig());
            this.InitializeComponent();
}

        public ListViewModel<FacebookDataConfig, FacebookSchema> ViewModel { get; set; }
        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
