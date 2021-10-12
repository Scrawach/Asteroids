using Components;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Toolbox/EngineSO", fileName = "EngineSO", order = 1)]
    public class EngineConfig : ScriptableObject
    {
        public EngineId Id;
        
        [Range(0, 10)] 
        public float MoveSpeed;

        [Range(0, 10)]
        public float RotateSpeed;

        [Range(0, 2)] 
        public float AccelerationModifier;
    }
}