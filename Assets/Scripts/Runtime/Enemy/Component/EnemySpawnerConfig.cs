using System.ComponentModel;
using Unity.Entities;
using Unity.Mathematics;

namespace VitaliyNull.Runtime.Enemy
{
    public struct EnemySpawnerConfig : IComponentData
    {
        public Entity EnemyPrefab;
        public float SpawnInterval;
        public float SpawnRate;
        public AABB SpawnArea;
        public float SpawnTimer;
    }
}