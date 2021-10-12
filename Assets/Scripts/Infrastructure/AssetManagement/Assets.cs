using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class Assets : IAssets
    {
        private readonly IAssetsDatabase _assetsDatabase;

        public Assets(IAssetsDatabase assetsDatabase) => 
            _assetsDatabase = assetsDatabase;

        public TResource Instantiate<TResource>(string path) where TResource : Object =>
            Instantiate<TResource>(path, Vector3.zero);

        public TResource Instantiate<TResource>(string path, Vector3 at) where TResource : Object => 
            Object.Instantiate(_assetsDatabase.Load<TResource>(path), at, Quaternion.identity);
        
    }
}