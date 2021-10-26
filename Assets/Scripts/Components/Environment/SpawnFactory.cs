using System;
using Components.Common;
using Extensions;
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
            var randomPointOnCircle = 5 * RandomPositionOnCircle();
            asteroid.GetComponent<EndlessMovement>().Construct(transform.position.AsVector2() - randomPointOnCircle);
            asteroid.transform.position = randomPointOnCircle;
        }

        private Vector2 RandomPositionOnCircle()
        {
            var angle = Random.Range(0, 360);
            var xPos = Mathf.Cos(angle);
            var yPos = Mathf.Sin(angle);
            return new Vector2(xPos, yPos);
        }
    }
}