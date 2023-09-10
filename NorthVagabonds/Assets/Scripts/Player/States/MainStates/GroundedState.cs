using UnityEngine;

namespace Player
{
    public class GroundedState : State
    {
        #region Inputs
        protected int xInput;
        protected bool jumpInput;
        #endregion

        protected bool onGround;

        public GroundedState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
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
            onGround = player.Core.CollisionSenses.Ground;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
        
            if (!onGround) stateMachine.ChangeState(player.InAirState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
