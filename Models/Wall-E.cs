using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class Wall_E : TestingUnit
    {
        public Wall_E(string name,Coordinates parkingPos, Coordinates workingPos) : base("Wall-E",name,parkingPos,workingPos, 2, 4)
        {
        }
        public override string ToString()
        {
            return "Wall-E";
        }
    }
} 