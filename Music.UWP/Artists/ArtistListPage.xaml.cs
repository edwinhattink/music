using Music.Model.Data;
using Music.Model;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;

namespace Music.UWP.Artists
{
    public sealed partial class ArtistListPage : Page
    {
        private Artist _lastArtist;

        public ArtistListPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            using (ModelContext db = new ModelContext())
            {
                Artists.ItemsSource = db.Artists.ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Artist artist = new Artist { Name = NewArtistName.Text };
                db.Artists.Add(artist);
                db.SaveChanges();

                Artists.ItemsSource = db.Artists.ToList();
            }
        }
        

        private void ArtistClick(object sender, ItemClickEventArgs e)
        {
            Artist clickedItem = (Artist)e.ClickedItem;
            _lastArtist = clickedItem;
            
            Frame.Navigate(typeof(ArtistDetailPage), clickedItem.Id, new DrillInNavigationTransitionInfo());            
        }
        
    }
}
