using UnityEngine;

namespace Core
{
    public class CoreComponent : MonoBehaviour 
    {
        protected Core Core {get; private set; }

        public virtual void Awake() 
        {
            Core = transform.parent.GetComponent<Core>();    
        }
    }
}