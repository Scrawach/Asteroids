using UnityEngine;

namespace Components.OutOfBoard
{
    public abstract class InvisibleObserver : MonoBehaviour
    {
        private bool _isInvisible;
        
        private void OnBecameInvisible() => 
            _isInvisible = true;

        protected void OnUpdate()
        {
            if (_isInvisible)
                OnBecameInvisibleSafe();
        }
        
        protected abstract void OnBecameInvisibleSafe();
    }
}