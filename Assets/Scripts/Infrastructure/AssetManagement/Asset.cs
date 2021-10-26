using StaticData;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class Asset<TAsset> : IAsset<TAsset> where TAsset : Object
    {
        private readonly IAssetsDatabase _database;
        private readonly string _path;

        public Asset(IAssetsDatabase database, string path)
        {
            _database = database;
            _path = path;
        }

        public TAsset Load() => 
            _database.Load<TAsset>(_path);
    }
}