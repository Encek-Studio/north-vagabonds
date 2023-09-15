using UnityEngine;

namespace Player
{
    public class JumpState : AbilityState
    {
        public JumpState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Movement?.SetVelocityY(playerData.jumpPower);
            stateMachine.ChangeState(player.InAirState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}