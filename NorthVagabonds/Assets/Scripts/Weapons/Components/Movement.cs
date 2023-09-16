using UnityEngine;

namespace Weapons.Components
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {

        private Core.Movement coreMovement;
        private Core.Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

        protected override void Start() 
        {
            base.Start();

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
            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, coreMovement.FacingDirection);
        }

        private void HandleStopMovement()
        {
            CoreMovement.SetVelocityZero();
        }
    }
}