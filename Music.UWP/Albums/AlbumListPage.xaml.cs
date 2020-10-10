using Music.Model;
using Music.Model.Data;
using Music.Model.Repositories;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Music.UWP.Albums
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlbumListPage : Page
    {
        public AlbumListPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Albums.ItemsSource = AlbumRepository.GetList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Album album = new Album { Name = NewAlbumName.Text };
            AlbumRepository.SaveAlbum(album);
            Albums.ItemsSource = AlbumRepository.GetList();
        }


        private void AlbumClick(object sender, ItemClickEventArgs e)
        {
            Album clickedItem = (Album)e.ClickedItem;

            Frame.Navigate(typeof(AlbumDetailPage), clickedItem.Id, new DrillInNavigationTransitionInfo());
        }
    }
}
