using Unity.Entities;
using UnityEngine;

namespace VitaliyNull.Runtime.Input
{
    public class PlayerBaker : MonoBehaviour
    {
        public class Baker : Baker<PlayerBaker>
        {
            public override void Bake(PlayerBaker authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new PlayerTag());
                AddComponent(entity, new InputData());
            }
        }
    }
}