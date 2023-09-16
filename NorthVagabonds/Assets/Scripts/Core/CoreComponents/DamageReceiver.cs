using UnityEngine;

namespace Core
{
    public class DamageReceiver : CoreComponent, IDamageable
    {
         private CoreComp<Stats> stats;
    
        protected override void Awake()
        {
            base.Awake();

            stats = new CoreComp<Stats>(core);
        }
        
        public void Damage(float amount) {
            Debug.Log(core.transform.parent.name + " Damaged!");
            stats.Component?.DecreaseHealth(amount);
        }
    }
}