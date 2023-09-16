using UnityEngine;

namespace Core
{
    public class KnockbackReceiver : CoreComponent, IKnockbackable
    {
        [SerializeField] private float maxKnockBackTime = 0.2f;

        private bool isKnockBackActive;
        private float knockBackStartTime;

        private CoreComp<Movement> movement;
        private CoreComp<CollisionSenses> collisionSenses;

        
        protected override void Awake()
        {
            base.Awake();

            movement = new CoreComp<Movement>(core);
            collisionSenses = new CoreComp<CollisionSenses>(core);
        }

        public override void LogicUpdate()
        {
            CheckKnockBack();
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            movement.Component?.SetVelocity(strength, angle, direction);
            movement.Component.CanSetVelocity = false;
            isKnockBackActive = true;
            knockBackStartTime = Time.time;
        }

        private void CheckKnockBack()
        {
            if (isKnockBackActive
                && ((movement.Component?.CurrentVelocity.y <= 0.01f && collisionSenses.Component.Ground)
                || Time.time >= knockBackStartTime + maxKnockBackTime)
               )
            {
                isKnockBackActive = false;
                movement.Component.CanSetVelocity = true;
            }
        }
    }
}