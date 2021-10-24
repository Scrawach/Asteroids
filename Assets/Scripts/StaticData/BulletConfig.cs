using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class BulletConfig
    {
        [Range(1, 10)]
        public float Speed;
    }
}