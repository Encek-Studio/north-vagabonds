using UnityEngine;

namespace Player
{
    public class RollState : AbilityState
    {
        private float lastRollTime;

        public RollState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }

        public override void Enter()
        {
            lastRollTime = Time.time;
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
            Movement?.SetVelocityX(Movement.FacingDirection * playerData.rollSpeed);
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public bool CanRoll() => Time.time >= lastRollTime + playerData.rollCooldown;
    }
}