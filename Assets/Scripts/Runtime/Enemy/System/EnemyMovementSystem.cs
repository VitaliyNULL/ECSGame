using Unity.Entities;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Enemy.System
{
    [UpdateInGroup(typeof(ReadInputSystemGroup))]
    public partial struct EnemyMovementSystem : ISystem
    {
    }
}