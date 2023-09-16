using System;
using Core;
using UnityEngine;

namespace Weapons.Components
{
    public class ActionHitbox : WeaponComponent<ActionHitboxData, AttackActionHitbox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2D;

        private CoreComp<Core.Movement> movement;

        private Vector2 offset;
        private Collider2D[] detected;

        protected override void Start()
        {
            base.Start();
            movement = new(Core);
            eventHandler.OnAttackAction += HandleAttackAction;
        }

        protected override void OnDestroy() 
        {
            base.OnDestroy();
            eventHandler.OnAttackAction -= HandleAttackAction;
        }

        private void HandleAttackAction()
        {
            offset.Set(
                transform.position.x + (currentAttackData.HitBox.center.x * movement.Component.FacingDirection),
                transform.position.y + currentAttackData.HitBox.center.y
            );

            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);
            
            if(detected.Length == 0) return;

            OnDetectedCollider2D?.Invoke(detected);
        }

        private void OnDrawGizmos() 
        {
            if (data == null) return;

            foreach(var item in data.AttackData)
            {
                if (!item.Debug) continue;

                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
    }
}