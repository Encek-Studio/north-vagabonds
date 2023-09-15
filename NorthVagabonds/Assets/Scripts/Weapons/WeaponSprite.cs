using UnityEngine;

namespace Weapons.Components
{
    public class WeaponSprite : WeaponComponent 
    {
        private SpriteRenderer baseSpriteRenderer;
        private SpriteRenderer weaponSpriteRenderer;
        [SerializeField] private WeaponSprites[] weaponSprites;

        private int currentWeaponSpriteIndex;

        private void HandleBaseSpriteChange(SpriteRenderer sr)
        {
            if (!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null;
                return;
            }
            
            Sprite[] currentAttackSprites = weaponSprites[weapon.CurrentAttackCounter].Sprites;

            weaponSpriteRenderer.sprite = currentAttackSprites[currentWeaponSpriteIndex];
            
            currentWeaponSpriteIndex++;
        }

        protected override void HandleEnter()
        {
            base.HandleEnter();
            currentWeaponSpriteIndex = 0;
        }

        protected override void Awake()
        {
            base.Awake();

            baseSpriteRenderer = transform.Find("Base").gameObject.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = transform.Find("WeaponSprite").gameObject.GetComponent<SpriteRenderer>();

            // TODO: Fix this when we create weapon data
            // baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
            // weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();
        }

        protected override void OnEnable() 
        {
            base.OnEnable();

            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
            weapon.OnEnter += HandleEnter;
        }

        protected override void OnDisable() 
        {
            base.OnDisable();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);
            weapon.OnEnter -= HandleEnter;
        }
    }

    [System.Serializable]
    public class WeaponSprites
    {
        [field: SerializeField] public Sprite[] Sprites { get ; private set; }
    }
}