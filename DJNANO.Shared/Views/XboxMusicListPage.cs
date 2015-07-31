using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class XboxMusicListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, XboxMusic1Schema> ViewModel { get; set; }

        public XboxMusicListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, XboxMusic1Schema>(new XboxMusicConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
