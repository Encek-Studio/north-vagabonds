using UnityEngine;

namespace Weapons.Components
{
    public class MovementData : ComponentData<AttackMovement>
    {
        public MovementData()
        {
            ComponentDependency = typeof(Movement);
        }
    }
}