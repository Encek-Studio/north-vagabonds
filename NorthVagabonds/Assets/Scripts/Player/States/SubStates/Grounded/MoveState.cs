using UnityEngine;

namespace Player
{
    public class MoveState : GroundedState
    {
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
            if (xInput == 0) stateMachine.ChangeState(player.IdleState);
            else
            {
                Movement?.SetVelocityX(xInput * playerData.moveSpeed);
                Movement?.CheckIfShouldFlip(xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}