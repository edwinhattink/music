using Music.Model;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Music.Model.Repositories;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Music.UWP.Artists
{
    public sealed partial class ArtistDetailPage : Page
    {
        public Artist Artist
        {
            get; set;
        }

        public ArtistDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Parameter is item ID
            Artist = ArtistRepository.GetById((int)e.Parameter);
        }

    }
}
