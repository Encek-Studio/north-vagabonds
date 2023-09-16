using UnityEngine;

namespace Core
{
    public class CoreComp<T> where T : CoreComponent
    {
        private readonly Core core;
        private T component;

        public T Component => component ? component : core.GetCoreComponent(ref component);

        public CoreComp(Core core)
        {
            if (core == null) Debug.LogWarning($"Core is NULL for component {typeof(T)}");
            this.core = core;
        }
    }
}