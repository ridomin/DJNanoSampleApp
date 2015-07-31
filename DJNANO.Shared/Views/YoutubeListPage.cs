using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using DJNANO;
using DJNANO.Sections;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class YoutubeListPage : PageBase
    {
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public YoutubeListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new YoutubeConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
