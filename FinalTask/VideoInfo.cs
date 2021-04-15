using System;
using System.Threading.Tasks;
using System.Text;
using YoutubeExplode;

namespace FinalTask
{
    class VideoInfo
    {
        /// <summary>
        /// Печатает на экран информацию о видеролике
        /// </summary>
        /// <param name="id"> id ролика</param>
        /// <returns></returns>
        public async Task PrintInfo(string id)
        {
            var client = new YoutubeClient();
            
            var info = await client.Videos.GetAsync(id);

            var title = info.Title;
            var author = info.Author;
            var duration = info.Duration;

            Console.WriteLine("Информация о видео:");
            Console.WriteLine($"Название: {title}\n" +
                              $"Автор: {author}\n" +
                              $"Длительность:{duration}");
        }
    }
}
