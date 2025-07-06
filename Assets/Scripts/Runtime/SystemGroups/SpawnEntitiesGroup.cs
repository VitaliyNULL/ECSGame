using Unity.Entities;

namespace VitaliyNull.Runtime.SystemGroups
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    [UpdateBefore(typeof(WriteInputSystemGroup))]
    public partial class SpawnEntitiesGroup : ComponentSystemGroup
    {
    }
}