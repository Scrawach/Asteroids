using UnityEngine;

namespace Components.OutOfBoard
{
    public abstract class InvisibleObserver : MonoBehaviour
    {
        private bool _isInvisible;

        private void Update()
        {
            if (_isInvisible)
                OnBecameInvisibleSafe();
        }

        private void OnBecameInvisible() => 
            _isInvisible = true;

        protected abstract void OnBecameInvisibleSafe();
    }
}