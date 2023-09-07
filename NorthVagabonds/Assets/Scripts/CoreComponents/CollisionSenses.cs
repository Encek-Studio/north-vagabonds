using UnityEngine;

namespace Core
{
    public class CollisionSenses : CoreComponent
    {
        public Transform GroundCheck
        {
            get => GenericNotImplementedError<Transform>.TryGet(groundCheck, Core.transform.parent.name);
            private set => groundCheck = value;
        }

        public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
        public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask whatIsGround;

        public bool Ground
        {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}