using Unity.Entities;

namespace VitaliyNull.Runtime.SystemGroups
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class WriteInputSystemGroup : ComponentSystemGroup
    {
        
    }
}