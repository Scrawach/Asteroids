using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class Asset : IAsset
    {
        private readonly IAssetsDatabase _database;
        private readonly string _path;

        public Asset(IAssetsDatabase database, string path)
        {
            _database = database;
            _path = path;
        }

        public TAsset Instantiate<TAsset>() where TAsset : Object => 
            (TAsset)Object.Instantiate(_database.Load<Object>(_path));
    }
}