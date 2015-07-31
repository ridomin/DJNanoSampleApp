using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class VideosListPage : PageBase
    {
        public VideosListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new VideosConfig());
            this.InitializeComponent();
}

        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }
        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
