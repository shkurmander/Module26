using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    /// <summary>
    /// Класс менеджера команд(Sender)
    /// </summary>
    class VideoManager
    {
        ICommand[] _commands;
        string _id;
        /// <summary>
        /// Задаем по-умолчанию массив пустых команд, чтобы не словить исключение при запуске,
        /// если перед этим не задали команды.
        /// </summary>
        public VideoManager(string videoId)
        {
            _id = videoId;
            _commands = new ICommand[2];

            for (int i = 0; i < _commands.Length; i++)
            {
                _commands[i] = new NoCommand();
            }
        }
        /// <summary>
        /// Устанавливаем команду 
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(int number, ICommand command)
        {
            _commands[number] = command;            
        }
        /// <summary>
        /// метод запускает на выполнение команду из массива команд, с переданным индексом number
        /// </summary>
        /// <param name="number"></param>
        public void Execute(int number)
        {
             _commands[number].Execute(_id);
        }


    }
}
