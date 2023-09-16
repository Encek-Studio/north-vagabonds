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

        private bool showForceUpdateButtons;
        private bool showAddComponentButtons;

        private void OnEnable() 
        {
            data = target as WeaponData;    
        }

        public override void OnInspectorGUI() 
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Set Number of Attacks"))
            {
                foreach (var item in data.ComponentDatas)
                {
                    item.InitializeAttackData(data.NumberOfAttacks);
                }
            }

            showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");
            
            if (showAddComponentButtons)
            {
                foreach (var dataComponentType in dataComponentTypes)
                {
                    if (GUILayout.Button(dataComponentType.Name))
                    {
                        if (Activator.CreateInstance(dataComponentType) is not ComponentData component) return;

                        component.InitializeAttackData(data.NumberOfAttacks);

                        data.AddData(component);
                    }
                }
            }

            showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Update Component Names");

            if (showForceUpdateButtons)
            {
                if (GUILayout.Button("Force Update Component Names"))
                {
                    foreach (var item in data.ComponentDatas)
                    {
                        item.SetComponentName();
                    }
                }

                if (GUILayout.Button("Force Update Attack Names"))
                {
                    foreach (var item in data.ComponentDatas)
                    {
                        item.SetAttackDataNames();
                    }
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