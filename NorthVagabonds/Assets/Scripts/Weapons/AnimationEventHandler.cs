using System;
using UnityEngine;

namespace Weapons
{
    public class AnimationEventHandler : MonoBehaviour 
    {
        public event Action OnFinished;

        private void AnimationFinishedTrigger() => OnFinished?.Invoke();
    }
}