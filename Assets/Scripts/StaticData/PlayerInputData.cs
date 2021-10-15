using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "Toolbox/PlayerInputData", fileName = "PlayerInputSO", order = 0)]
    public class PlayerInputData : ScriptableObject
    {
        public string HorizontalAxis = "Horizontal";
        public string VerticalAxis = "Vertical";
        public KeyCode Fire = KeyCode.Mouse0;
        public KeyCode AltFire = KeyCode.Mouse1;
    }
}