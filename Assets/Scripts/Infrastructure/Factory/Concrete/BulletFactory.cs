using Components;
using Components.Environment;
using Infrastructure.Factory.Abstract;
using UnityEngine;

namespace Infrastructure.Factory.Concrete
{
    public class BulletFactory
    {
        private readonly IObjectFactory _objectFactory;

        public BulletFactory(IObjectFactory objectFactory) => 
            _objectFactory = objectFactory;

        public GameObject Create(Vector3 at, Vector3 to)
        {
            var bullet = _objectFactory.Create();
            bullet.transform.position = at;
            bullet.GetComponent<EndlessMovement>().Construct(to);
            bullet.transform.right = to;
            return bullet;
        }
    }
}