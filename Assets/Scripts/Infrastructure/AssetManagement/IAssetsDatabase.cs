using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssetsDatabase
    {
        TResource Load<TResource>(string path) where TResource : Object;
        TResource[] LoadAll<TResource>(string path) where TResource : Object;
    }
}