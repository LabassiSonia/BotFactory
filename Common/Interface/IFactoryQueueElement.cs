using BotFactory.Common.Tools;

namespace Common.Interface
{
    public interface IFactoryQueueElement
    {
        string Name { get; set; }
        string Model { get; set; }
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
    }
}
