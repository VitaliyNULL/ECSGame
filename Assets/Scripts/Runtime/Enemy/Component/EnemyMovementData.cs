using Unity.Entities;
using Unity.Mathematics;

namespace VitaliyNull.Runtime.Enemy
{
    public struct EnemyMovementData : IComponentData
    {
        public float2 MovementDirection;
    }
}