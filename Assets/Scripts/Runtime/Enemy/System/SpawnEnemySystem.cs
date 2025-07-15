using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Enemy.System
{
    [UpdateInGroup(typeof(SpawnEntitiesGroup))]
    [BurstCompile]
    public partial struct SpawnEnemySystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<EnemySpawnerConfig>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var config = SystemAPI.GetSingletonRW<EnemySpawnerConfig>();
            config.ValueRW.SpawnTimer += SystemAPI.Time.DeltaTime;
            Random random = Random.CreateFromIndex((uint)(SystemAPI.Time.ElapsedTime * 1000));
            if (config.ValueRO.SpawnTimer >= config.ValueRO.SpawnInterval)
            {
                config.ValueRW.SpawnTimer = 0f;
                float3 min = config.ValueRO.SpawnArea.Center - config.ValueRO.SpawnArea.Extents;
                float3 max = config.ValueRO.SpawnArea.Center + config.ValueRO.SpawnArea.Extents;
                for (int i = 0; i < config.ValueRO.SpawnRate; i++)
                {
                    var entity = state.EntityManager.Instantiate(config.ValueRO.EnemyPrefab);
                    float3 randomPosition = random.NextFloat3(min, max);
                    state.EntityManager.SetComponentData(entity,
                        new LocalTransform() { Position = randomPosition, Rotation = quaternion.identity, Scale = 1f });
                }
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}