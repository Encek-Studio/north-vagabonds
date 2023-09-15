using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackSprites : AttackData
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}