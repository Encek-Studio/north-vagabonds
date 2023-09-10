namespace Player
{
    public class InAirState : State
    {
        protected int xInput;
        protected bool onGround;

        public InAirState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
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

            if (onGround) stateMachine.ChangeState(player.IdleState);
            else player.Core.Movement.SetVelocityX(xInput * playerData.moveSpeedInAir);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
