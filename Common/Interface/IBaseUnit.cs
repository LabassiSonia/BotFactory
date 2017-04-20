using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit:IReportingUnit { 
        //Properties
        string Name { get; set; }
        double Speed { get; set; }
        Coordinates CurrentPos { get; set; }
        //Methods
        Task<Coordinates> Move(Coordinates arrival);



    }
}
