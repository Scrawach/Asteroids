using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 AsVector2(this Vector3 self) =>
            new Vector2(self.x, self.y);
        
        public static Vector3 AsVector3(this Vector2 self) =>
            new Vector3(self.x, self.y, 0f);

        public static Quaternion AsRotation(this Vector2 self)
        {
            var angle = Mathf.Atan2(self.y, self.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}