using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace VitaliyNull.Runtime.Enemy
{
    public partial struct EnemySeekingJob : IJobEntity
    {
        [ReadOnly] public LocalTransform TargetTransform;
        public void Execute()
    }
}