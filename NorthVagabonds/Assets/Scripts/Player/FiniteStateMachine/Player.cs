using TMPro;
using UnityEngine;
using Weapons;

namespace Player
{
    public class Player : MonoBehaviour
    {
        #region Components
        public Animator Anim { get; private set; }
        public StateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Core.Core Core { get; private set; }
        #endregion

        #region States
        public IdleState IdleState {get; private set; }
        public MoveState MoveState {get; private set; }
        public JumpState JumpState {get; private set; }
        public InAirState InAirState {get; private set; }
        public RollState RollState {get; private set; }
        public AttackState AttackState {get; private set; }
        public HeavyAttackState HeavyAttackState {get; private set; }
        public DefenseState DefenseState {get; private set; }
        #endregion

        [SerializeField] private PlayerData playerData;
        private Weapon weapon;

        #region Temporary Variables
        [SerializeField] private TextMeshPro _currentStateText;
        #endregion
        
        #region BUILT-IN FUNCTIONS
        private void Awake()
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Core = GetComponentInChildren<Core.Core>();
            StateMachine = new();
        }

        private void Start() 
        {
            weapon = transform.Find("Weapon").GetComponent<Weapon>();

            InitStates();
            
            StateMachine.Initialize(IdleState);
            StateMachine.OnStateChanged += ChangeCurrentStateText; //ToDo: Delete it later!
        }

        private void Update() 
        {
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate() 
        {
            StateMachine.CurrentState.PhysicsUpdate();    
        }
        #endregion

        public void InitStates()
        {
            IdleState = new(this, StateMachine, playerData, "idle");
            MoveState = new(this, StateMachine, playerData, "move");
            JumpState = new(this, StateMachine, playerData, "inAir");
            InAirState = new(this, StateMachine, playerData, "inAir");
            RollState = new(this, StateMachine, playerData, "roll");
            AttackState = new(this, StateMachine, playerData, "attack", weapon);
            HeavyAttackState = new(this, StateMachine, playerData, "heavyAttack");
            DefenseState = new(this, StateMachine, playerData, "defense");
        }

        #region ANIMATION TRIGGER FUNCTIONS
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        #endregion

        #region Temporary Functions
        public void ChangeCurrentStateText()
        {
            _currentStateText.text = StateMachine.CurrentState.ToString();
        }
        #endregion
    }
}
