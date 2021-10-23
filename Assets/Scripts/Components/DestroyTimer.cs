using UnityEngine;

namespace Components
{
    public class DestroyTimer : MonoBehaviour
    {
        [SerializeField] 
        private float _waitInSeconds;

        private void Awake() => 
            Destroy(gameObject, _waitInSeconds);
    }
}