
using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace FinalTask
{
    class VideoDownloader
    {
        public async Task Download(string videoId)
        {
            var client = new YoutubeClient();                      

            var streams = await client.Videos.Streams.GetManifestAsync(videoId);
            var streamInfo = streams.GetMuxed().WithHighestVideoQuality();

            var fileName = $@"c:\Test\{videoId}.{streamInfo.Container.Name}";

            // Download video
            Console.Write($"Downloading stream: {streamInfo.VideoQualityLabel} / {streamInfo.Container.Name}... ");
            using (var progress = new InlineProgress())
                await client.Videos.Streams.DownloadAsync(streamInfo, fileName, progress);

            Console.WriteLine($"Video saved to '{fileName}'");
        }
    }
}
