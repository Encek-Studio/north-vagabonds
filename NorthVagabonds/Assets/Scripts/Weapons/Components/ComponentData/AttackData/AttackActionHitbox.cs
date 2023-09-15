 using UnityEngine;

namespace Weapons.Components
{
    [System.Serializable]
    public class AttackActionHitbox : AttackData
    {
        public bool Debug;
        [field: SerializeField] public Rect HitBox { get; private set; }
    }
}