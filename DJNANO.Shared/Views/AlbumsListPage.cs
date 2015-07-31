using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class AlbumsListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, Albums1Schema> ViewModel { get; set; }

        public AlbumsListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, Albums1Schema>(new AlbumsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
