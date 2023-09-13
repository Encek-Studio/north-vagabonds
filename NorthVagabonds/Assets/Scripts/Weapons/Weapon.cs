using System;
using UnityEngine;
using Utilities;

namespace Weapons
{
    public class Weapon : MonoBehaviour 
    {
        [SerializeField] private int numberOfAttacks;
        [SerializeField] private float attackCounterResetCooldown;

        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= numberOfAttacks ? 0 : value;
        }
        public event Action OnExit;
        private Animator anim;
        private GameObject baseGameObject;
        private AnimationEventHandler eventHandler;

        private int currentAttackCounter;
        private Timer attackCounterResetTimer;

        #region BUILT-IN FUNCTIONS
        private void Awake() 
        {
            baseGameObject = transform.Find("Base").gameObject;
            anim = baseGameObject.GetComponent<Animator>();
            eventHandler = baseGameObject.GetComponent<AnimationEventHandler>(); 

            attackCounterResetTimer = new(attackCounterResetCooldown);  
        }

        private void OnEnable() 
        {
            eventHandler.OnFinished += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable() 
        {
            eventHandler.OnFinished -= Exit;    
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }

        private void Update() 
        {
            attackCounterResetTimer.Tick();
        }
        #endregion

        public void Enter()
        {
            Debug.Log($"{transform.name} enter");
            attackCounterResetTimer.StopTimer();
            anim.SetBool("active", true);
            anim.SetInteger("counter", currentAttackCounter);
        }

        private void Exit()
        {
            anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();
            OnExit?.Invoke();
        }

        private void ResetAttackCounter() 
        {
            CurrentAttackCounter = 0;
            Debug.Log("Reset Attack Counter");
        }
    }
}