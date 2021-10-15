using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAsset
    {
        TAsset Instantiate<TAsset>() where TAsset : Object;
    }
}