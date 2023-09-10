using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public bool JumpInput {get; private set; }
        public bool RollInput {get; private set; }
        public bool AttackInput {get; private set; }
        public bool HeavyAttackInput {get; private set; }
        public bool DefenseInput {get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            NormInputX = Mathf.RoundToInt(RawMovementInput.normalized.x);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
                JumpInput = true;
            else if (context.canceled)
                JumpInput = false;
        }

        public void OnRoll(InputAction.CallbackContext context)
        {
            if (context.started)
                RollInput = true;
            else if (context.canceled)
                RollInput = false;
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                AttackInput = true;
            else if (context.canceled)
                AttackInput = false;
        }

        public void OnHeavyAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                HeavyAttackInput = true;
            else if (context.canceled)
                HeavyAttackInput = false;
        }

        public void OnDefense(InputAction.CallbackContext context)
        {
            if (context.started)
                DefenseInput = true;
            else if (context.canceled)
                DefenseInput = false;
        }
    }
}
