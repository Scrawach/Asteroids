using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
        public static bool Contains(this LayerMask self, int digit) => 
            ((1 << digit) & self) > 0;
    }
}