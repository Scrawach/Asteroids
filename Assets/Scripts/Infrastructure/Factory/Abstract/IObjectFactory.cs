using UnityEngine;

namespace Infrastructure.Factory.Abstract
{
    public interface IObjectFactory
    {
        GameObject Create();
    }
}