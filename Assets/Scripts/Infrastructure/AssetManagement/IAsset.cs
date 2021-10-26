using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAsset<out TAsset> where TAsset : Object
    {
        TAsset Load();
    }
}