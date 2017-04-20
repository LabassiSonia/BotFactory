using Common.Tools;

namespace BotFactory.Common.Interface
{
    public interface IReportingUnit :IBuildableUnit
    {
        event UnitStatusChangedHandler UnitStatusChanged;
        void OnStatusChanged(string NewStatus);
    }
}
