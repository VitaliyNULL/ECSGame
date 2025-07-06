using Unity.Entities;
using UnityEngine;
using VitaliyNull.Runtime.Input;

namespace VitaliyNull.Runtime.Movement
{
    public class PlayerAuthoring : MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }

        public class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerTag());
                AddComponent(entity, new InputData());
                AddComponent(entity, new PlayerSpeedData() { Speed = authoring.Speed });
            }
        }
    }
}