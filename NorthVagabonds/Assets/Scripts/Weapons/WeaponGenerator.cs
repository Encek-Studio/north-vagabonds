using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Weapons.Components;

namespace Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponData data;

        private List<WeaponComponent> componentsAlreadyOnWeapon = new();
        private List<WeaponComponent> componentsAddedToWeapon = new();
        private List<Type> componentDependencies = new();

        private void Start() 
        {
            GenerateWeapon(data);
        }

        public void GenerateWeapon(WeaponData data)
        {
            weapon.SetData(data);

            componentsAlreadyOnWeapon.Clear();
            componentsAddedToWeapon.Clear();
            componentDependencies.Clear();

            componentsAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();
            componentDependencies = data.GetAllDependencies();

            foreach (var dependency in componentDependencies)
            {
                if (componentsAddedToWeapon.FirstOrDefault(component => component.GetType() == dependency)) continue;

                var weaponComponent = componentsAlreadyOnWeapon.FirstOrDefault(component => component.GetType() == dependency)
                                      ?? gameObject.AddComponent(dependency) as WeaponComponent;

                weaponComponent.Init();

                componentsAddedToWeapon.Add(weaponComponent);
            }

            var componentsToRemove = componentsAlreadyOnWeapon.Except(componentsAddedToWeapon);

            foreach (var weaponComponent in componentsToRemove)
            {
                Destroy(weaponComponent);
            }
        }
    }
}