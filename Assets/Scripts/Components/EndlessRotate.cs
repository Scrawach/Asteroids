using System;
using UnityEngine;

namespace Components
{
    public class EndlessRotate : MonoBehaviour
    {
        [SerializeField] 
        private float _speedInDegrees;

        private void Update() => 
            transform.Rotate(0, 0, _speedInDegrees * Time.deltaTime);
    }
}