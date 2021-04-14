using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace FinalTask
{
//    Задание
//Используя паттерн Команда и созданный выше шаблон, напишите консольную программу, которая будет:
//Принимать на вход ссылку на Youtube-видео.
//Выводить в консоль информацию: название видео и описание.
//Скачивать видео.
//У вас должно быть две команды: на получение информации о видео и на скачивание.
    class Program
    {
        static  async Task<int> Main()
        {
            var client = new YoutubeClient();

            Console.Write("Enter YouTube video ID or URL: ");
            var videoId = new VideoId(Console.ReadLine()!);

            var streams = await client.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streams.GetMuxed().WithHighestVideoQuality();

            var videoInfo = await client.Videos.GetAsync(videoId);

            var title = videoInfo.Title; 
            var author = videoInfo.Author;
            var duration = videoInfo.Duration;

            var fileName = $@"c:\Test\{videoId}.{streamInfo.Container.Name}";

            // Download video
            Console.Write($"Downloading stream: {streamInfo.VideoQualityLabel} / {streamInfo.Container.Name}... ");
            using (var progress = new InlineProgress())
                await client.Videos.Streams.DownloadAsync(streamInfo, fileName, progress);

            Console.WriteLine($"Video saved to '{fileName}'");


            Console.ReadKey();

            return 0;
        }
    }
}
