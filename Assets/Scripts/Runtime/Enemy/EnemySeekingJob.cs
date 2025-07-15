using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace VitaliyNull.Runtime.Enemy
{
    [BurstCompile]
    [WithAll(typeof(EnemyTag))]
    public partial struct EnemySeekingJob : IJobEntity
    {
        [ReadOnly] public NativeArray<float3> TargetPositions;

        [BurstCompile]
        public void Execute([EntityIndexInChunk] int index, RefRO<LocalTransform> transform,
            RefRO<EnemySeekerData> enemySeekerData,
            RefRW<EnemyMovementData> movementData)
        {
            float3 currentPos = transform.ValueRO.Position;
            float minDistanceSqr = enemySeekerData.ValueRO.SeekingRadiusSqr;
            var closest = movementData.ValueRO.MoveDestination;
            bool found = false;
            foreach (var pos in TargetPositions)
            {
                var distance = math.distancesq(currentPos, pos);
                if (distance < minDistanceSqr)
                {
                    minDistanceSqr = distance;
                    closest = pos;
                    found = true;
                }
            }

            if (found)
            {
                movementData.ValueRW.MoveDestination = closest;
                movementData.ValueRW.IsDestinationSet = true;
            }
        }
    }
}