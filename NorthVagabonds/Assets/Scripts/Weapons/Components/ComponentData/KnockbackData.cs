using UnityEngine;

namespace Weapons.Components
{
    public class KnockbackData : ComponentData<AttackKnockback>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Knockback);
        }
    }
}