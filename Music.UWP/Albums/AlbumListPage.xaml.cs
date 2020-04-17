using Music.Model;
using Music.Model.Data;
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

            using (ModelContext db = new ModelContext())
            {
                Albums.ItemsSource = db.Albums.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Album album = new Album { Name = NewAlbumName.Text };
                db.Albums.Add(album);
                db.SaveChanges();

                Albums.ItemsSource = db.Albums.ToList();
            }
        }


        private void AlbumClick(object sender, ItemClickEventArgs e)
        {
            Album clickedItem = (Album)e.ClickedItem;

            Frame.Navigate(typeof(AlbumDetailPage), clickedItem.Id, new DrillInNavigationTransitionInfo());
        }
    }
}
