using BotFactory.Common.Tools;

namespace BotFactory.Models
{
    public class R2D2 : TestingUnit
    {
       

        public R2D2(string name,Coordinates parkingPos, Coordinates workingPos) : base("R2D2",name,parkingPos,workingPos, 1.5,5.5)
        {
        }

        public override string ToString()
        {
            return "R2D2";
        }
    }
}
