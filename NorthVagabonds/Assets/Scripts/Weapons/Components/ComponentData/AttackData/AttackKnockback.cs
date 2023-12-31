using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackKnockback : AttackData
    {
        [field: SerializeField] public Vector2 Angle { get; private set; }
        [field: SerializeField] public float Strength { get; private set; }
    }
}