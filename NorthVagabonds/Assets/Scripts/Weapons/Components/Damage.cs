using System;
using UnityEngine;

namespace Weapons.Components
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitbox hitbox;

        protected override void Awake() 
        {
            base.Awake();
            hitbox = GetComponent<ActionHitbox>();
        }

        protected override void OnEnable() 
        {
            base.OnEnable();
            hitbox.OnDetectedCollider2D += HandleDetectedCollider2D;
        }

        protected override void OnDisable() 
        {
            base.OnDisable();
            hitbox.OnDetectedCollider2D -= HandleDetectedCollider2D;
        }

        private void HandleDetectedCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(currentAttackData.Amount);
                }
            }
        }
    }

}