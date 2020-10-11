using Music.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Music.Model.Repositories;

namespace Music.UWP.Albums
{
    public sealed partial class AlbumDetailPage : Page
    {
        public Album Album { get; set; }

        public AlbumDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Album = AlbumRepository.GetById((int)e.Parameter);       
        }
        
    }
}
