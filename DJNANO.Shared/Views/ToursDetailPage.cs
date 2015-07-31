using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views

{
    public sealed partial class ToursDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<DynamicStorageDataConfig, Tours1Schema> ViewModel { get; set; }

        public ToursDetailPage()
        {
            this.ViewModel = new DetailViewModel<DynamicStorageDataConfig, Tours1Schema>(new ToursConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
