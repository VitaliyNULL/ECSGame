using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace VitaliyNull.Runtime.Enemy
{
    public class EnemySpawnerAuthoring : MonoBehaviour
    {
        [field: SerializeField] public EnemyAuthoring EnemyPrefab { get; private set; }
        [field: SerializeField] public float SpawnInterval { get; private set; } = 2f;
        [field: SerializeField] public float SpawnRate { get; private set; } = 1f;

        [field: SerializeField]
        public Bounds SpawnBounds { get; private set; } = new Bounds(Vector3.zero, new Vector3(10f, 10f, 10f));

        public class Baker : Baker<EnemySpawnerAuthoring>
        {
            public override void Bake(EnemySpawnerAuthoring authoring)
            {
                var entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                AddComponent(entity, new EnemySpawnerConfig()
                {
                    EnemyPrefab = GetEntity(authoring.EnemyPrefab, TransformUsageFlags.Dynamic),
                    SpawnInterval = authoring.SpawnInterval,
                    SpawnRate = authoring.SpawnRate,
                    SpawnArea = new AABB
                    {
                        Center = authoring.SpawnBounds.center,
                        Extents = authoring.SpawnBounds.extents
                    }
                });
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(SpawnBounds.center, SpawnBounds.size);
        }
    }
}