using UnityEngine;
using Weapons;

namespace Player
{
    public class AttackState : AbilityState
    {
        private Weapon weapon;

        public AttackState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName, Weapon weapon) : base(player, stateMachine, playerData, animationName)
        {
            this.weapon = weapon;
            weapon.OnExit += ExitHandler;
        }

        public override void Enter()
        {
            base.Enter();
            weapon.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        private void ExitHandler()
        {
            AnimationFinishTrigger();
            isAbilityDone = true;
        }
    }
}