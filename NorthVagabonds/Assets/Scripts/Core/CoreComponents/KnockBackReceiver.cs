using UnityEngine;

namespace Core
{
    public class KnockbackReceiver : CoreComponent, IKnockbackable
    {
        [SerializeField] private float maxKnockbackTime = 0.2f;

        private bool isKnockbackActive;
        private float knockbackStartTime;

        private Movement movement;
        private CollisionSenses collisionSenses;

        
        protected override void Awake()
        {
            base.Awake();

            movement = core.GetCoreComponent<Movement>();
            collisionSenses = core.GetCoreComponent<CollisionSenses>();
        }

        public override void LogicUpdate()
        {
            CheckKnockback();
        }

        public void Knockback(Vector2 angle, float strength, int direction)
        {
            movement.SetVelocity(strength, angle, direction);
            movement.CanSetVelocity = false;
            isKnockbackActive = true;
            knockbackStartTime = Time.time;
        }

        private void CheckKnockback()
        {
            if (isKnockbackActive
                && ((movement.CurrentVelocity.y <= 0.01f && collisionSenses.Ground)
                || Time.time >= knockbackStartTime + maxKnockbackTime)
               )
            {
                isKnockbackActive = false;
                movement.CanSetVelocity = true;
            }
        }
    }
}