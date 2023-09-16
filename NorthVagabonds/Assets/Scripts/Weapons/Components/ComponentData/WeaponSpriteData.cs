using UnityEngine;

namespace Weapons.Components
{
    public class WeaponSpriteData : ComponentData<AttackSprites>
    {
        public WeaponSpriteData()
        {
            ComponentDependency = typeof(WeaponSprite);
        }
    }
}