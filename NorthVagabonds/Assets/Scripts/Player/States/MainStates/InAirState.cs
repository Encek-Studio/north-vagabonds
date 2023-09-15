using Core;

namespace Player
{
    public class InAirState : State
    {
        protected Movement Movement
        {
            get => movement ?? core.GetCoreComponent(ref movement);
        }

        private CollisionSenses CollisionSenses
        {
            get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses);
        }

        private Movement movement;
        private CollisionSenses collisionSenses;

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
            if (CollisionSenses)
            {
                onGround = CollisionSenses.Ground;
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.InputHandler.NormInputX;

            if (onGround) stateMachine.ChangeState(player.IdleState);
            else 
            {
                Movement?.SetVelocityX(xInput * playerData.moveSpeedInAir);
                Movement?.CheckIfShouldFlip(xInput);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
