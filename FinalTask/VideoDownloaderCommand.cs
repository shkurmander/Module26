using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class VideoDownloaderCommand : ICommand
    {
        VideoDownloader _downloader;
        string _url;
        public VideoDownloaderCommand(VideoDownloader downloader,string url)
        {
            _downloader = downloader;
            _url = url;
        }
        public void Execute()
        {
            _downloader.Download(_url);
        }
    }
}
