using UnityEngine;

namespace Enemy
{
    public class TestEnemy : MonoBehaviour, IDamageable
    {
        public Core.Core Core { get; private set; }

        private void Awake() 
        {
            Core = transform.GetComponentInChildren<Core.Core>();    
        }

        public void Damage(float amount)
        {
            Debug.Log($"Taken Damage: {amount}");
        }

        public void Update()
        {
            Core.LogicUpdate();
        }

    }
}