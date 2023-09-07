using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public Animator Anim { get; private set; }
        public StateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Core.Core Core { get; private set; }

        private void Awake() 
        {
            Anim = GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            Core = GetComponentInChildren<Core.Core>();
        }

        private void Start() 
        {
            StateMachine = new();
        }
    }
}
