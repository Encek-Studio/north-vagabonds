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
        public event Action OnEnter;
        public event Action OnExit;
        public GameObject BaseGameObject { get ; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }
        private Animator anim;
        private AnimationEventHandler eventHandler;

        private int currentAttackCounter;
        private Timer attackCounterResetTimer;

        #region BUILT-IN FUNCTIONS
        private void Awake() 
        {
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
            anim = BaseGameObject.GetComponent<Animator>();
            eventHandler = BaseGameObject.GetComponent<AnimationEventHandler>(); 

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
            OnEnter?.Invoke();
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