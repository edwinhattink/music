using Music.Model;
using Music.Model.Data;
using Music.Model.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Music.UWP.Genres
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GenreListPage : Page
    {
        public GenreListPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Genres.ItemsSource = GenreRepository.GetList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = new Genre { Name = NewGenreName.Text };
            GenreRepository.SaveGenre(genre);
            Genres.ItemsSource = GenreRepository.GetList();
        }


        private void Artist_Click(object sender, ItemClickEventArgs e)
        {
            Genre clickedItem = (Genre)e.ClickedItem;

            Frame.Navigate(typeof(GenreDetailPage), clickedItem.Id, new DrillInNavigationTransitionInfo());
        }
    }
}
