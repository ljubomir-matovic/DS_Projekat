using MG_58_2020.Models;

namespace MG_58_2020
{
    public interface IMemento
    {
        GameControllerResponse response { get; set; }
        Field[,] fields { get; set; }

        int pogodjeno { get; set; }
    }
}