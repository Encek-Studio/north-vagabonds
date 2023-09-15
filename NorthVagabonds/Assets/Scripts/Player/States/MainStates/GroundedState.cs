using Core;

namespace Player
{
    public class GroundedState : State
    {
        #region Inputs
        protected int xInput;
        protected bool jumpInput;
        protected bool attackInput;
        protected bool heavyAttackInput;
        protected bool defenseInput;
        protected bool rollInput;
        #endregion

        protected Movement Movement
        {
        get => movement ? movement : core.GetCoreComponent(ref movement);
        }

        private CollisionSenses CollisionSenses
        {
            get => collisionSenses ? collisionSenses : core.GetCoreComponent(ref collisionSenses);
        }

        private Movement movement;
        private CollisionSenses collisionSenses;

        private bool onGround;

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
            if (CollisionSenses)
            {
                onGround = CollisionSenses.Ground;
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            attackInput = player.InputHandler.AttackInput;
            heavyAttackInput = player.InputHandler.HeavyAttackInput;
            defenseInput = player.InputHandler.DefenseInput;
            rollInput = player.InputHandler.RollInput;

            if (!onGround) stateMachine.ChangeState(player.InAirState);
            else if (jumpInput) stateMachine.ChangeState(player.JumpState);
            else if (rollInput && player.RollState.CanRoll()) stateMachine.ChangeState(player.RollState);
            else if (attackInput) stateMachine.ChangeState(player.AttackState);
            else if (heavyAttackInput) stateMachine.ChangeState(player.HeavyAttackState);
            else if (defenseInput) stateMachine.ChangeState(player.DefenseState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
