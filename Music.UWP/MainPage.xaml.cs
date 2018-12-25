using Music.Model;
using Music.Model.Data;
using Music.UWP.Services;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Music.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			using (ModelContext db = new ModelContext())
			{
				Artists.ItemsSource = db.Artists.ToList();
			}
			Mp3Reader reader = new Mp3Reader();
			reader.ReadFile();
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
	}
}
