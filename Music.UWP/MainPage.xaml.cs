using Music.Model;
using Music.Model.Data;
using Music.UWP.Artists;
using Music.UWP.Services;
using Music.UWP.ViewModels;
using System;
using System.Collections.Generic;
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
        private List<MenuButton> menuButtons = new List<MenuButton>();

        public MainPage()
        {
            this.InitializeComponent();
            menuButtons.Add(new MenuButton("Artists", "\xE13D", typeof(ArtistListPage)));
            menuButtons.Add(new MenuButton("Albums", "\xE93C", typeof(AlbumListPage)));
            menuButtons.Add(new MenuButton("Genres", "\xEC4F", typeof(AlbumListPage)));
            IconsListBox.ItemsSource = menuButtons;

        }

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Mp3Reader reader = new Mp3Reader();
			reader.ReadFile();
		}

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuButton selectedButton = (MenuButton) IconsListBox.SelectedItem;
            MyFrame.Navigate(selectedButton.NavigateTo);
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
