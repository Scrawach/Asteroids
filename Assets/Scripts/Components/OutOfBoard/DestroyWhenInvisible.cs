using System;

namespace Components.OutOfBoard
{
    public class DestroyWhenInvisible : InvisibleObserver
    {
        private void Update() => 
            OnUpdate();

        protected override void OnBecameInvisibleSafe() => 
            Destroy(gameObject);
    }
}