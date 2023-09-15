using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections.Generic;
using System;
using Weapons.Components;
using System.Reflection;
using System.Linq;

namespace Weapons
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataEditor : Editor 
    {
        private static List<Type> dataComponentTypes = new();
        private WeaponData data;

        private void OnEnable() 
        {
            data = target as WeaponData;    
        }

        public override void OnInspectorGUI() 
        {
            base.OnInspectorGUI();

            foreach (var dataComponentType in dataComponentTypes)
            {
                if (GUILayout.Button(dataComponentType.Name))
                {
                    ComponentData component = Activator.CreateInstance(dataComponentType) as ComponentData;
                    
                    if (component == null) return;

                    data.AddData(component);
                }
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) 
                && !type.ContainsGenericParameters
                && type.IsClass
            );

            dataComponentTypes = filteredTypes.ToList();
        }
    }
}