using UnityEngine;

namespace Player
{
    public class AttackState : AbilityState
    {
        public AttackState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
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
    }
}