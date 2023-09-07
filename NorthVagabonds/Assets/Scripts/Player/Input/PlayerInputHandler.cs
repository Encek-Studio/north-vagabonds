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

        public void UseJumpInput() => JumpInput = false;
        public void UseRollInput() => RollInput = false;
    }
}
