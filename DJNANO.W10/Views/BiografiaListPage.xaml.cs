using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Html;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class BiografiaListPage : PageBase
    {
        private DataTransferManager _dataTransferManager;

        public BiografiaListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new BiografiaConfig());
            this.InitializeComponent();
}

        public ListViewModel<LocalStorageDataConfig, HtmlSchema> ViewModel { get; set; }
        public string HtmlContent
        {
            get
            {
                if (ViewModel.Items != null && ViewModel.Items.Count > 0)
                {
                    return ViewModel.Items[0].Content;
                }
                return string.Empty;
            }
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
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
            ViewModel.ShareContent(args.Request);
        }
    }
}
