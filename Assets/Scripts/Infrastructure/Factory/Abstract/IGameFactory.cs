using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public interface IGameFactory
    {
        GameObject Create(ObjectId objectId);
    }
}