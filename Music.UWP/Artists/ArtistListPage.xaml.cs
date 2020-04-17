using Music.Model.Data;
using Music.Model;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Music.Model.Repositories;

namespace Music.UWP.Artists
{
    public sealed partial class ArtistListPage : Page
    {
        public ArtistListPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Artists.ItemsSource = ArtistRepository.GetList();
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
        

        private void Artist_Click(object sender, ItemClickEventArgs e)
        {
            Artist clickedItem = (Artist) e.ClickedItem;
            
            Frame.Navigate(typeof(ArtistDetailPage), clickedItem.Id, new DrillInNavigationTransitionInfo());            
        }
        
    }
}
