using Unity.Entities;
using Unity.Mathematics;

namespace VitaliyNull.Runtime.Enemy
{
    public struct EnemySeekerData : IComponentData
    {
        public float SeekingRadius;
        public float3 TargetPosition;
        public bool IsTargetInRange;
    }
}