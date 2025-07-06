using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace VitaliyNull.Runtime.Input
{
    public partial class UserInputSystem : SystemBase
    {
        private InputSystem_Actions _inputActions;

        protected override void OnCreate()
        {
            RequireForUpdate<InputData>();
            _inputActions = new InputSystem_Actions();
            _inputActions.Enable();
        }

        protected override void OnUpdate()
        {
            var moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
            var entity = SystemAPI.GetSingletonEntity<InputData>();
            EntityManager.SetComponentData(entity, new InputData
            {
                MovementAxis = new float2(moveInput.x, moveInput.y)
            });
        }
    }
}