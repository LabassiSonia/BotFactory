using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class T_800 : WorkingUnit
    {
        public T_800(string name,Coordinates parkingPos, Coordinates workingPos) : base("T-800",name,parkingPos,workingPos, 3,10)
        {
        }
        public override string ToString()
        {
            return "T_800";
        }
    }
}
