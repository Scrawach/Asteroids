using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Death))]
    public class DestroyAfterDeath : MonoBehaviour
    {
        private Death _death;

        private void Awake() => 
            _death = GetComponent<Death>();

        private void OnEnable() => 
            _death.Happened += OnDeathHappened;

        private void OnDisable() => 
            _death.Happened -= OnDeathHappened;

        private void OnDeathHappened(Death obj) => 
            Destroy(gameObject);
    }
}