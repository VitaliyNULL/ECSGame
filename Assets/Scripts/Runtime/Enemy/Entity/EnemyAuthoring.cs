using Unity.Entities;
using UnityEngine;

namespace VitaliyNull.Runtime.Enemy
{
    public class EnemyAuthoring : MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float SeekingRadius { get; private set; }

        public class Baker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new EnemyTag());
                AddComponent(entity, new EnemySpeedData() { Speed = authoring.Speed });
                AddComponent(entity, new EnemyMovementData());
                AddComponent(entity, new EnemySeekerData()
                {
                    SeekingRadius = authoring.SeekingRadius
                });
            }
        }
    }
}