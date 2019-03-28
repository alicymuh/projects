using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Musics_App
{
    public class Music
    {

        private const string TEXT_FILE_NAME = "Music.txt";
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Filepath { get; set; }
        public string DisplayName { get; set; }
      

        public static async Task<ICollection<Music>> getMusic()
        {
            var musics = new List<Music>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            
            var lines = fileContent.Split(new char[] { '\r', '\n' });
         
            foreach (var line in lines)
            {

                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(';');
                var Music = new Music
                { Title = lineParts[0],
                  Artist = lineParts[1],
                  Album = lineParts[2],
                  Filepath = lineParts[3],
                  DisplayName= lineParts[4]
                };
                musics.Add(Music);
                
                
            }
               
             return musics;
        }

        public static void writeMusicDetails(Music mus, string FileName)
        {
            var musiccontent = $"{ mus.Title};{mus.Artist};{mus.Album};{mus.Filepath};{mus.DisplayName}";
            FileHelper.writeFileAsync(FileName, musiccontent);
        }
            
        
    }
}
