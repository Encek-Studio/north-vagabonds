using UnityEngine;

namespace Enemy
{
    public class TestEnemy : MonoBehaviour, IDamageable
    {
        public void Damage(float amount)
        {
            Debug.Log($"Taken Damage: {amount}");
        }
    }
}