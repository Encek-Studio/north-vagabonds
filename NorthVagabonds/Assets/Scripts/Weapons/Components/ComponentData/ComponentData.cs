using System;
using UnityEngine;

namespace Weapons.Components
{
    [Serializable]
    public class ComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public ComponentData()
        {
            SetComponentName();
        }

        public void SetComponentName() => name = GetType().Name;

        public virtual void SetAttackDataNames(){}
        public virtual void InitializeAttackData(int numberOfAttacks){}
    }

    [Serializable]
    public class ComponentData<T> : ComponentData where T : AttackData
    {
        [SerializeField] private T[] attackData;
        public T[] AttackData { get => attackData; private set => attackData = value; }

        public override void InitializeAttackData(int numberOfAttacks)
        {
            base.InitializeAttackData(numberOfAttacks);

            int oldLength = attackData == null ? 0 : AttackData.Length;

            if (oldLength == numberOfAttacks) return;

            Array.Resize(ref attackData, numberOfAttacks);

            if (oldLength < numberOfAttacks)
            {
                for (int i = oldLength; i < attackData.Length; i++)
                {
                    var newObject = Activator.CreateInstance(typeof(T)) as T;
                    attackData[i] = newObject;
                }
            }

            SetAttackDataNames();
        }

        public override void SetAttackDataNames()
        {
            base.SetAttackDataNames();

            for (int i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i + 1);
            }
        }
    }
}