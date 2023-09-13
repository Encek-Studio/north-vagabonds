namespace Player
{
    public class AbilityState : State
    {
        protected bool isAbilityDone;
        protected bool onGround;

        public AbilityState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }
        public override void Enter()
        {
            base.Enter();
            isAbilityDone = false;
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
             if (isAbilityDone)
             {
                if (onGround && player.Core.Movement.CurrentVelocity.y < 0.01f) stateMachine.ChangeState(player.IdleState);
                else stateMachine.ChangeState(player.InAirState);
             }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
