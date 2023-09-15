using UnityEngine;

namespace Core
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core core;

        protected virtual void Awake()
        {
            
            if(!transform.parent.TryGetComponent<Core>(out core)) { Debug.LogError("There is no Core on the parent"); }
            core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}