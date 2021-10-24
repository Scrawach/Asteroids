namespace Components.OutOfBoard
{
    public class DestroyWhenInvisible : InvisibleObserver
    {
        protected override void OnBecameInvisibleSafe() => 
            Destroy(gameObject);
    }
}