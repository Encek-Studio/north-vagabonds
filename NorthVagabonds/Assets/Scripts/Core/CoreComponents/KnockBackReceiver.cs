using UnityEngine;

namespace Core
{
    public class KnockbackReceiver : CoreComponent, IKnockbackable
    {
        [SerializeField] private float maxKnockbackTime = 0.2f;

        private bool isKnockbackActive;
        private float knockbackStartTime;

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
            CheckKnockback();
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            movement.Component?.SetVelocity(strength, angle, direction);
            movement.Component.CanSetVelocity = false;
            isKnockbackActive = true;
            knockbackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (isKnockbackActive
                && ((movement.Component?.CurrentVelocity.y <= 0.01f && collisionSenses.Component.Ground)
                || Time.time >= knockbackStartTime + maxKnockbackTime)
               )
            {
                Debug.Log(collisionSenses.Component.Ground);
                isKnockbackActive = false;
                movement.Component.CanSetVelocity = true;
            }
        }
    }
}