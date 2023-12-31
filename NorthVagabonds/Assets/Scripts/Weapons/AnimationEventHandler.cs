using System;
using UnityEngine;

namespace Weapons
{
    public class AnimationEventHandler : MonoBehaviour 
    {
        public event Action OnFinished;
        public event Action OnStartMovement;
        public event Action OnStopMovement;
        public event Action OnAttackAction;
        public event Action<AttackPhases> OnEnterAttackPhase;

        private void AnimationFinishedTrigger() => OnFinished?.Invoke();
        private void StartMovementTrigger() => OnStartMovement?.Invoke();
        private void StopMovementTrigger() => OnStopMovement?.Invoke();
        private void AttackActionTrigger() => OnAttackAction?.Invoke();
        private void EnterAttackPhase(AttackPhases phase) => OnEnterAttackPhase?.Invoke(phase); 
    }
}