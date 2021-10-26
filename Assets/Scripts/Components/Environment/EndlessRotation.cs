using UnityEngine;

namespace Components.Environment
{
    public class EndlessRotation : MonoBehaviour
    {
        [SerializeField] 
        private float _speedInDegrees;
        
        private void Update() => 
            transform.Rotate(0, 0, _speedInDegrees * Time.deltaTime);
    }
}