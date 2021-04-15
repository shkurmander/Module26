
using System.Threading.Tasks;

namespace FinalTask
{
    /// <summary>
    /// Базовый интерфейс для команд
    /// </summary>
    interface ICommand
    {
        void  Execute(string id);

    }
}
