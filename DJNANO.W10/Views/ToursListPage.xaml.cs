using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class ToursListPage : PageBase
    {
        public ToursListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, Tours1Schema>(new ToursConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, Tours1Schema> ViewModel { get; set; }
        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
            ToursConfig.RemoveDeprecatedTours(ViewModel.Items);
        }

    }
}
