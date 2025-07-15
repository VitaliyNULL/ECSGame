using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Enemy.System
{
    [UpdateInGroup(typeof(ReadInputSystemGroup))]
    [BurstCompile]
    public partial struct EnemyMovementSystem : ISystem
    {
        [BurstCompile]

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemyMovementData>();
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, movementData, speedData) in SystemAPI
                         .Query<RefRW<LocalTransform>, RefRO<EnemyMovementData>, RefRO<EnemySpeedData>>()
                         .WithAll<EnemyTag>())
            {
                float3 direction = math.normalize(movementData.ValueRO.MoveDestination - transform.ValueRO.Position);
                transform.ValueRW.Position +=
                    direction * SystemAPI.Time.DeltaTime * speedData.ValueRO.Speed;
            }
        }
    }
}