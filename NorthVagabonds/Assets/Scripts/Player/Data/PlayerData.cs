using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("MOVEMENT")]
        public float moveSpeed = 10f;
        public float moveSpeedInAir = 7.5f;

        [Space(6)]
        [Header("JUMP")]
        public float jumpPower = 10f;

        [Space(6)]
        [Header("IN AIR")]
        public float coyoteTime = .2f;

        [Space(6)]
        [Header("ROLL")]
        public float rollSpeed = 20f;
        public float rollCooldown = 1f;
        public float rollTime = .3f;
    }
}
