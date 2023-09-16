using System;
using Core;
using UnityEngine;

namespace Weapons.Components
{
    public class Knockback : WeaponComponent<KnockbackData, AttackKnockback>
    {
        private ActionHitbox hitbox;

        private Core.Movement movement;

        protected override void Awake() 
        {
            base.Awake();
        }

        protected override void Start() 
        {
            base.Start();
            hitbox = GetComponent<ActionHitbox>();
            hitbox.OnDetectedCollider2D += HandleDetectedCollider2D;
            
            movement = Core.GetCoreComponent<Core.Movement>();
        }

        protected override void OnDestroy() 
        {
            base.OnDestroy();
            hitbox.OnDetectedCollider2D -= HandleDetectedCollider2D;
        }

        private void HandleDetectedCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IKnockbackable knockbackable))
                {
                    knockbackable.Knockback(currentAttackData.Angle, currentAttackData.Strength, movement.FacingDirection);
                }
            }
        }
    }

}