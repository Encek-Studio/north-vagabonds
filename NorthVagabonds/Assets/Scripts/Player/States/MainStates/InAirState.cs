namespace Player
{
    public class InAirState : State
    {
        public InAirState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }
    }
}
