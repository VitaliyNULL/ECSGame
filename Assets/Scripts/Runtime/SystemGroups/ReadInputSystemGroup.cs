using Unity.Entities;

namespace VitaliyNull.Runtime.SystemGroups
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateAfter(typeof(WriteInputSystemGroup))]
    public partial class ReadInputSystemGroup : ComponentSystemGroup
    {
    }
}