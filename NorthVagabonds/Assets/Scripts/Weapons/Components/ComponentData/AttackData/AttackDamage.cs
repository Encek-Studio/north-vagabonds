using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackDamage : AttackData
    {
        [field: SerializeField] public float Amount { get; private set; }
    }
}