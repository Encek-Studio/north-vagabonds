using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackPoiseDamage : AttackData
    {
        [field: SerializeField] public float Amount { get; private set; } 
    }
}