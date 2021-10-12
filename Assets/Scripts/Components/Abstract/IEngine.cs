using UnityEngine;

namespace Components.Abstract
{
    public interface IEngine
    {
        void Move(Vector2 to);
        void Rotate(Vector2 to);
    }
}