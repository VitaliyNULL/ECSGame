using Unity.Entities;
using Unity.Mathematics;

namespace VitaliyNull.Runtime.Enemy
{
    public struct EnemyMovementData : IComponentData
    {
        public float3 MoveDestination;
        public bool IsDestinationSet;
    }
}