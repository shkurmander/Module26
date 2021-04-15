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
        static  async Task Main()
        {
            
            //ЗАпрашиваем ссылку на видео и формируем VideoID
            Console.Write("Enter YouTube video ID or URL: ");
            var videoId = new VideoId(Console.ReadLine()!);

          

            //Создаем объект менеджера (Sender)
            var manager = new VideoManager(videoId);

            //Создаем объекты исполнителя (Recevier)
            var videoInfo = new VideoInfo();
            var downloader = new VideoDownloader();

            //Задаем команды в менеджере и передаем в них исполнителя
            manager.SetCommand(0, new VideoInfoCommand(videoInfo));
            manager.SetCommand(1, new VideoDownloaderCommand(downloader));
            
            //Запускаем команды
            manager.Execute(0);
            manager.Execute(1);


            Console.ReadKey();

            
        }
    }
}
