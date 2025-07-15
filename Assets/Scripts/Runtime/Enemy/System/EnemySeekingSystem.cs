using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VitaliyNull.Runtime.Movement;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Enemy.System
{
    [UpdateInGroup(typeof(WriteInputSystemGroup))]
    [BurstCompile]
    public partial struct EnemySeekingSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlayerTag>();
        }

        [BurstCompile]

        public void OnUpdate(ref SystemState state)
        {
            var playerTransforms = new NativeList<float3>(Allocator.TempJob);
            foreach (var player in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<PlayerTag>())
            {
                playerTransforms.Add(player.ValueRO.Position);
            }

            var job = new EnemySeekingJob()
            {
                TargetPositions = playerTransforms.AsArray(),
            };
            var handle = job.ScheduleParallel(state.Dependency);
            playerTransforms.Dispose(handle);
            state.Dependency = handle;
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}