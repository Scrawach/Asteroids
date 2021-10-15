using System;
using Infrastructure.Factory.Abstract;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components.Environment
{
    public class SpawnFactory : MonoBehaviour
    {
        private IObjectFactory _factory;
        private MonoTimer _cooldown;
        
        public void Construct(IObjectFactory asteroidFactory, float cooldown)
        {
            _factory = asteroidFactory;
            _cooldown = new MonoTimer(cooldown);
        }

        private void FixedUpdate()
        {
            if (CanSpawn())
            {
                Spawn();
                _cooldown.Start();
            }
            else
            {
                _cooldown.Update(Time.fixedDeltaTime);
            }
        }

        private bool CanSpawn() => 
            _cooldown.IsDone;

        private void Spawn()
        {
            var asteroid = _factory.Create();
            var randomPointOnCircle = 5 * Random.insideUnitCircle;
            asteroid.transform.position = randomPointOnCircle;
        }
    }
}