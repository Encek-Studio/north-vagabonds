using UnityEngine;

namespace Player
{
    public class IdleState : GroundedState
    {
        public IdleState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.Core.Movement.SetVelocityX(0);
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
            if (xInput != 0) stateMachine.ChangeState(player.MoveState);
            else if (jumpInput) stateMachine.ChangeState(player.JumpState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}