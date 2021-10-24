using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Toolbox/WeaponSO", fileName = "WeaponSO", order = 1)]
    public class WeaponConfig : ScriptableObject
    {
        public BulletConfig BulletConfig;
        
        [Range(0, 2)]
        public float Cooldown;
    }
}