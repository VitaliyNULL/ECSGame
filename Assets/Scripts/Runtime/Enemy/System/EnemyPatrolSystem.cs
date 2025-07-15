using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Enemy.System
{
    [UpdateInGroup(typeof(WriteInputSystemGroup))]
    [UpdateAfter(typeof(EnemySeekingSystem))]
    [BurstCompile]
    public partial struct EnemyPatrolSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemyTag>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, movementData, entity) in SystemAPI
                         .Query<RefRO<LocalTransform>, RefRW<EnemyMovementData>>()
                         .WithAll<EnemyTag>().WithEntityAccess())
            {
                if (movementData.ValueRO.IsDestinationSet) continue;
                var random = new Random((uint)entity.Index);
                var direction = random.NextFloat3Direction();
                var distance = random.NextFloat(5f, 10f);
                movementData.ValueRW.MoveDestination = transform.ValueRO.Position + direction * distance;
                movementData.ValueRW.IsDestinationSet = true;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}