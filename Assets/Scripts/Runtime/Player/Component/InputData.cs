using Unity.Entities;
using Unity.Mathematics;

namespace VitaliyNull.Runtime.Input
{
    public struct InputData : IComponentData
    {
        public float2 MovementAxis;
    }
}