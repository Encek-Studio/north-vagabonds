using System;
using UnityEngine;
using Utilities;

namespace Weapons
{
    public class Weapon : MonoBehaviour 
    {
        public WeaponData Data { get; private set; }
        
        [SerializeField] private float attackCounterResetCooldown;
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value;
        }
        public event Action OnEnter;
        public event Action OnExit;
        public GameObject BaseGameObject { get ; private set; }
        public GameObject WeaponSpriteGameObject { get; private set; }
        public AnimationEventHandler EventHandler { get; private set; }
        public Core.Core Core { get; private set; }
        private Animator anim;

        private int currentAttackCounter;
        private Timer attackCounterResetTimer;

        #region BUILT-IN FUNCTIONS
        private void Awake() 
        {
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
            anim = BaseGameObject.GetComponent<Animator>();
            EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>(); 

            attackCounterResetTimer = new(attackCounterResetCooldown);  
        }

        private void OnEnable() 
        {
            EventHandler.OnFinished += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable() 
        {
            EventHandler.OnFinished -= Exit;    
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

        public void SetCore(Core.Core core) => Core = core;

        private void ResetAttackCounter() 
        {
            CurrentAttackCounter = 0;
            Debug.Log("Reset Attack Counter");
        }

        public void SetData(WeaponData data) => Data = data;
    }
}