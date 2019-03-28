using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace Musics_App
{
    public static class FileHelper
    {
        public static async void writeFileAsync (string fileName, string content)
        {
           var localFolder = ApplicationData.Current.LocalFolder;
           var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            if (!File.ReadLines(file.Path).Any(line => line.Contains(content)))
            {
                File.AppendAllText(file.Path, content + Environment.NewLine);
                
            }

                 
        }

        public static async Task<string> ReadTextFileAsync(string filename)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var textFile = await localFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }
    }
}
