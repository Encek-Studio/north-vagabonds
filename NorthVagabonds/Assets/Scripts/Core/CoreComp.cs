using UnityEngine;

namespace Core
{
    public class CoreComponent<T> where T : CoreComponent
    {
        private Core core;
        private T component;

        public T Component => component ? component : core.GetCoreComponent(ref component);

        public CoreComponent(Core core)
        {
            if (core == null) Debug.LogWarning($"Core is NULL for component {typeof(T)}");
            this.core = core;
        }
    }
}