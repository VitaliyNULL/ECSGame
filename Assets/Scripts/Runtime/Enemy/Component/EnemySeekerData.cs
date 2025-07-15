using Unity.Entities;

namespace VitaliyNull.Runtime.Enemy
{
    public struct EnemySeekerData : IComponentData
    {
        public float SeekingRadius;
        public float SeekingRadiusSqr => SeekingRadius * SeekingRadius;
    }
}