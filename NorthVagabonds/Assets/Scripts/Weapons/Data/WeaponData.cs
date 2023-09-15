using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapons.Components;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponData_", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponData : ScriptableObject 
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        [field: SerializeReference] public List<ComponentData> ComponentDatas { get; private set; }

        public T GetData<T>()
        {
            return ComponentDatas.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("Add Sprite Data")]
        private void AddSpriteData() => ComponentDatas.Add(new WeaponSpriteData());
        
        [ContextMenu("Add Movement Data")]
        private void AddMovementData() => ComponentDatas.Add(new MovementData());
    }
}