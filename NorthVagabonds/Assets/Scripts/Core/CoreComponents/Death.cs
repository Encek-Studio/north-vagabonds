using System;
using UnityEngine;

namespace Core
{
    public class Death : CoreComponent
    {
        private Stats stats;

        protected override void Awake()
        {
            base.Awake();
            stats = core.GetCoreComponent<Stats>();
        }

        private void OnEnable() 
        {
            stats.Health.OnCurrentValueZero += Die;    
        }

        private void OnDisable() 
        {
            stats.Health.OnCurrentValueZero -= Die;    
        }

        public void Die()
        {
            core.transform.parent.gameObject.SetActive(false);
        }
    }

}