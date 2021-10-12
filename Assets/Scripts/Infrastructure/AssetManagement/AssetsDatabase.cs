using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class AssetsDatabase : IAssetsDatabase
    {
        public TResource Load<TResource>(string path) where TResource : Object => 
            Resources.Load<TResource>(path);

        public TResource[] LoadAll<TResource>(string path) where TResource : Object => 
            Resources.LoadAll<TResource>(path);
    }
}