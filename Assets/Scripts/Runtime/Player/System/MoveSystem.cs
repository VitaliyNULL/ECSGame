using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using VitaliyNull.Runtime.Input;
using VitaliyNull.Runtime.SystemGroups;

namespace VitaliyNull.Runtime.Movement
{
    [UpdateInGroup(typeof(ReadInputSystemGroup))]
    public partial struct MoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<InputData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, input) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<InputData>>()
                         .WithAll<PlayerTag>())
            {
                transform.ValueRW.Position = transform.ValueRO.Position +
                                             new float3(input.ValueRO.MovementAxis.x, 0, input.ValueRO.MovementAxis.y) *
                                             SystemAPI.Time.DeltaTime * 5f;
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}