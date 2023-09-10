using UnityEngine;

namespace Player
{
    public class MoveState : GroundedState
    {
        private bool rollInput;

        public MoveState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            rollInput = player.InputHandler.RollInput;

            if (xInput == 0) stateMachine.ChangeState(player.IdleState);
            else if (jumpInput) stateMachine.ChangeState(player.JumpState);
            else if (rollInput) stateMachine.ChangeState(player.RollState);
            else if (attackInput) stateMachine.ChangeState(player.AttackState);
            else if (heavyAttackInput) stateMachine.ChangeState(player.HeavyAttackState);
            else if (defenseInput) stateMachine.ChangeState(player.DefenseState);
            else 
            {
                player.Core.Movement.SetVelocityX(xInput * playerData.moveSpeed);
                player.Core.Movement.CheckIfShouldFlip(xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}