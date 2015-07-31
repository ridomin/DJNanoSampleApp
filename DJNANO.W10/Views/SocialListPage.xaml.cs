using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class SocialListPage : PageBase
    {
        public SocialListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new SocialConfig());
            this.InitializeComponent();
}

        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }
        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
