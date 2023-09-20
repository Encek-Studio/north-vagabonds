using UnityEngine;

namespace Weapons.Components
{
    public class PoiseDamage : WeaponComponent<PoiseDamageData, AttackPoiseDamage>
    {
        private ActionHitbox hitbox;

        protected override void Awake() 
        {
            base.Awake();
        }

        protected override void Start() 
        {
            base.Start();
            hitbox = GetComponent<ActionHitbox>();
            hitbox.OnDetectedCollider2D += HandleDetectedCollider2D;
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
                if (item.TryGetComponent(out IPoiseDamageable poiseDamageable))
                {
                    poiseDamageable.Damage(currentAttackData.Amount);
                }
            }
        }
    }
}