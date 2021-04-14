using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    class VideoInfoCommand : ICommand
    {
        VideoInfo _info;
        string _url;
        public VideoInfoCommand(VideoInfo info, string url)
        {
            _info = info;
            _url = url;
        }
        public void Execute()
        {
            _info.PrintInfo(_url);
        }
    }
}
