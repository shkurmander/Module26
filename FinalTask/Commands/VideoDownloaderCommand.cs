using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class VideoDownloaderCommand : ICommand
    {
        VideoDownloader _downloader;
        
        public VideoDownloaderCommand(VideoDownloader downloader)
        {
            _downloader = downloader;
        
        }
        public void Execute(string id)
        {

            var task = _downloader.Download(id);
            task.Wait();
            ;
        }
    }
}
