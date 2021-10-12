using UnityEngine;

namespace Components
{
    public interface IWeapon
    {
        bool TryFire();
    }
    
    public class Weapon : MonoBehaviour
    {

    }
}