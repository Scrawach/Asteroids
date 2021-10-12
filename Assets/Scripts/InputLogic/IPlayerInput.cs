using UnityEngine;

namespace InputLogic
{
    public interface IPlayerInput
    {
        Vector2 Axis { get; }
        Vector2 Mouse { get; }
        bool IsAttackButtonDown();
        bool IsAlternativeAttackButtonDown();
    }
}