using UnityEngine;

namespace Core
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
         private Stats stats;
    
        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }
        
        public void Damage(float amount) {
            Debug.Log(core.transform.parent.name + " Damaged!");
            stats.Health.Decrease(amount);
        }
    }
}