
using System.Threading.Tasks;

namespace FinalTask
{
    /// <summary>
    /// класс команды VideoInfo
    /// </summary>
    class VideoInfoCommand : ICommand
    {
        VideoInfo _info;
        
        public VideoInfoCommand(VideoInfo info)
        {
            _info = info;
           
        }
        public void Execute(string id)
        {
            // Запускаем метод чере Task, т.к. методы внутри асинхронные, иначе если видео короткое, 
            // загрузка пройдет быстрее чем выведется информация о видео
            
            var task = _info.PrintInfo(id);
            task.Wait();
        }
    }
}
