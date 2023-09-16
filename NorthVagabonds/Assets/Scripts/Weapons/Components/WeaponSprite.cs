using UnityEngine;

namespace Weapons.Components
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
    {
        private SpriteRenderer baseSpriteRenderer;
        private SpriteRenderer weaponSpriteRenderer;

        private int currentWeaponSpriteIndex;

        protected override void Start()
        {
            base.Start();

            baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            data = weapon.Data.GetData<WeaponSpriteData>();
            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
        }

        protected override void OnDestroy() 
        {
            base.OnDestroy();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);
        }

        private void HandleBaseSpriteChange(SpriteRenderer sr)
        {
            if (!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null;
                return;
            }
            
            Sprite[] currentAttackSprites = currentAttackData.Sprites;

            weaponSpriteRenderer.sprite = currentAttackSprites[currentWeaponSpriteIndex];
            
            currentWeaponSpriteIndex++;
        }

        protected override void HandleEnter()
        {
            base.HandleEnter();
            currentWeaponSpriteIndex = 0;
        }
    }
}