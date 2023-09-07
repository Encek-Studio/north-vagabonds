namespace Player
{
    public class AbilityState : State
    {
        public AbilityState(Player player, StateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
        {
        }
    }
}
