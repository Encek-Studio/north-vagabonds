namespace Player
{
    public class AbilityState : State
    {
        protected bool onGround;

        public AbilityState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
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
             if (isAnimationFinished)
             {
                if (onGround) stateMachine.ChangeState(player.IdleState);
                else stateMachine.ChangeState(player.InAirState);
             }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
