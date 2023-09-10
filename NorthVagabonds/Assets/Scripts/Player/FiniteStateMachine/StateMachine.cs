
namespace Player
{
    public class StateMachine
    {
        public State CurrentState {get; private set; }
        public State PreviousState {get; private set; }

        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            PreviousState = CurrentState;
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
