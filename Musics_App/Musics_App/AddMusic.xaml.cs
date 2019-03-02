using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Musics_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMusic : Page
    {
        public static readonly string[] audioExtensions = new string[] { ".wma", ".mp3", ".mp2", ".aac", ".adt", ".adts", ".m4a" };
        public AddMusic()
        {
            this.InitializeComponent();
        }

        private async void PickAudio_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            string[] audioExtensions = new string[] { ".wma", ".mp3", ".mp2", ".aac", ".adt", ".adts", ".m4a" };
            var Title = "";

            foreach (string extension in audioExtensions)
            {
                picker.FileTypeFilter.Add(extension);
            }
            StorageFile file = await picker.PickSingleFileAsync();
            StorageFolder assets = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            //StorageFile sampleFile = await assets.CreateFileAsync("sample.txt",NameCollisionOption.ReplaceExisting);
            await file.CopyAsync(assets, file.DisplayName + Path.GetExtension(file.Path), NameCollisionOption.ReplaceExisting);
            //StorageFolder storageFolder = KnownFolders.MusicLibrary;
            //StorageFile file_song = await storageFolder.CreateFileAsync(file.Path, CreationCollisionOption.ReplaceExisting);
            MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();



            var Artist = musicProperties.Artist;
             
            var Album = musicProperties.Album;
            var songName = file.DisplayName;
            var FilePath = file.Path;
            var newMusic = new Music
            {
                Title = Title,
                Artist = Artist,
                Album = Album,
                Filepath = FilePath,
                DisplayName = songName
            };
            Music.writeMusicDetails(newMusic, "Music.txt");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
{