using System;
using System.Collections.Generic;
using DefaultNamespace.ScriptableEvents;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] private AsteroidSet _asteroids;


        public void OnAsteroidHitByLaser(int asteroidId)
        {
            Asteroid asteroid = _asteroids.Get(asteroidId);

            Destroy(asteroid.gameObject);
            UnregisterAsteroid(asteroid);
        }

        private void UnregisterAsteroid(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid);
        }
    }
}