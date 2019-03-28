using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Musics_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaPlayer player;
        //MediaPlayerElement player;
        public MainPage()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = await Music.getMusic();
        }

        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("10,000 Reasons (Bless the Lord) - Matt Redman (Best Worship Song Ever) (with Lyrics).mp3");
          

        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("10,000 Reasons (Bless the Lord) - Matt Redman (Best Worship Song Ever) (with Lyrics).mp3");
          

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMusic));
        }

        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMusic));
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Music clicked = (Music)e.ClickedItem;
            var namedis = clicked.DisplayName;
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(clicked.DisplayName+Path.GetExtension(clicked.Filepath));
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
          
        }
    }
}
