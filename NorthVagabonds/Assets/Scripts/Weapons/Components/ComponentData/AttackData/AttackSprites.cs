using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackSprites : AttackData
    {
        [field: SerializeField] public PhaseSprites[] PhaseSprites { get; private set; }
    }

    [System.Serializable]
    public struct PhaseSprites
    {
        [field: SerializeField] public AttackPhases Phase { get; private set; } 
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}