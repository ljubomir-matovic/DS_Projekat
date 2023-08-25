using MG_58_2020.Models;

namespace MG_58_2020
{
    public class ConcreteMemento : IMemento
    {
        public GameControllerResponse response { get; set; }
        public Field[,] fields { get; set; }
        public int pogodjeno { get; set; }
    }
}