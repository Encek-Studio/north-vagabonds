using UnityEngine;

namespace Core
{
    public class PoiseDamageReceiver : CoreComponent, IPoiseDamageable
    {
         private Stats stats;
    
        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
        }
        
        public void Damage(float amount) 
        {
            Debug.Log(core.transform.parent.name + " Poise Damaged!");
            stats.Poise.Decrease(amount);
        }
    }
}