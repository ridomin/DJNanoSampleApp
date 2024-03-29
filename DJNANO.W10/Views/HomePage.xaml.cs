using Windows.UI.Xaml.Navigation;
using DJNANO;
using DJNANO.ViewModels;

namespace DJNANO.Views
{
    public sealed partial class HomePage : PageBase
    {
        public HomePage()
        {
            ViewModel = new MainViewModel(8);            
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        public MainViewModel ViewModel { get; set; }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }
    }
}
