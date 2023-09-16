using Core;
using UnityEngine;

namespace Weapons.Components
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {

        private CoreComp<Core.Movement> movement;

        protected override void Start() 
        {
            base.Start();

            movement = new(Core);

            eventHandler.OnStartMovement += HandleStartMovement;
            eventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy() 
        {
            base.OnDestroy();

            eventHandler.OnStartMovement -= HandleStartMovement;
            eventHandler.OnStopMovement -= HandleStopMovement;
        }

        private void HandleStartMovement()
        {
            movement.Component.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, movement.Component.FacingDirection);
        }

        private void HandleStopMovement()
        {
            movement.Component.SetVelocityZero();
        }
    }
}