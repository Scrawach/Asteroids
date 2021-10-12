using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssets
    {
        TResource Instantiate<TResource>(string path) where TResource : Object;
        TResource Instantiate<TResource>(string path, Vector3 at) where TResource : Object;
    }
}