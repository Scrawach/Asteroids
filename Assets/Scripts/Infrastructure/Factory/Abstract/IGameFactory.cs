using System;
using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public interface IGameFactory : IDisposable
    {
        GameObject Create(ObjectId objectId);
    }
}