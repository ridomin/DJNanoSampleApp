using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class TwitterListPage : PageBase
    {
        public ListViewModel<TwitterDataConfig, TwitterSchema> ViewModel { get; set; }

        public TwitterListPage()
        {
            this.ViewModel = new ListViewModel<TwitterDataConfig, TwitterSchema>(new TwitterConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
