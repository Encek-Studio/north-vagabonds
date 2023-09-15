using UnityEngine;
using Core;

namespace Weapons.Components
{
    public class ActionHitboxData : ComponentData<AttackActionHitbox>
    {
        [field: SerializeField] public LayerMask DetectableLayers { get; private set; } 
    }
}