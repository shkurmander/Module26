using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    /// <summary>
    /// Класс команды video downloader'a
    /// </summary>
    class VideoDownloaderCommand : ICommand
    {
        VideoDownloader _downloader;
        
        public VideoDownloaderCommand(VideoDownloader downloader)
        {
            _downloader = downloader;
        
        }
        public void Execute(string id)
        {
            // Запускаем метод чере Task, чтобы обесппечить последовательность вывода 
            // информаци на экран, т.к. методы внутри асинхронные и могут отработать вразнобой, обеспечив "кашу" на экране.
            
            var task = _downloader.Download(id);
            task.Wait();
            ;
        }
    }
}
