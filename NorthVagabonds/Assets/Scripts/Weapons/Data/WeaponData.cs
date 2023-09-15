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

        public void AddData(ComponentData data)
        {
            if (ComponentDatas.FirstOrDefault(t => t.GetType() == data.GetType()) != null) 
            {
                Debug.LogWarning($"{this.name} already contains a {data.GetType().Name}");
                return;
            }
            ComponentDatas.Add(data);
        }
    }
}