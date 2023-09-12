using UnityEngine;

namespace Player
{
    public class RollState : AbilityState
    {
        private float _lastRollTime;

        public RollState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }

        public override void Enter()
        {
            _lastRollTime = Time.time;
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
            player.Core.Movement.SetVelocityX(player.Core.Movement.FacingDirection * playerData.rollSpeed);
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public bool CanRoll() => Time.time >= _lastRollTime + playerData.rollCooldown;
    }
}