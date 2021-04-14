using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class NoCommand : ICommand
    {
        public void Execute(string id)
        {
            Console.WriteLine("Команда не задано - выполнение невозможно!");
        }

        
    }
}
