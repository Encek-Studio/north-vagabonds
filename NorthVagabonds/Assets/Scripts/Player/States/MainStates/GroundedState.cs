namespace Player
{
    public class GroundedState : State
    {
        #region Inputs

        #endregion

        protected bool onGround;

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
            onGround = player.Core.CollisionSenses.Ground;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
    }
}
