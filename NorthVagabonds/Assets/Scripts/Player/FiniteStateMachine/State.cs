using UnityEngine;

namespace Player
{
    public class State
    {
        protected Core.Core core;
        protected Player player;
        protected StateMachine stateMachine;
        protected PlayerData playerData;
        protected float startingTime;
        protected bool isAnimationFinished;
        private readonly string animationName;

        public State(Player player, StateMachine stateMachine, PlayerData playerData, string animationName)
        {
            this.player = player;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this.animationName = animationName;
            core = player.Core;
        } 

        public virtual void Enter()
        {
            player.Anim.SetBool(animationName, true);
            startingTime = Time.time;
            isAnimationFinished = false;
            DoChecks();
        }

        public virtual void Exit()
        {
            player.Anim.SetBool(animationName, false);
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
            
        }

        public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    }
}
