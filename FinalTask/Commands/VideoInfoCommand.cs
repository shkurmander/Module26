
using System.Threading.Tasks;

namespace FinalTask
{
    class VideoInfoCommand : ICommand
    {
        VideoInfo _info;
        
        public VideoInfoCommand(VideoInfo info)
        {
            _info = info;
           
        }
        public void Execute(string id)
        {
            var task = _info.PrintInfo(id);
            task.Wait();
        }
    }
}
