using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidSet")]
    public class AsteroidSet : ScriptableObject
    {
        private Dictionary<int, Asteroid> _asteroids = new Dictionary<int, Asteroid>();

        private void Awake()
        {
            Clear();
        }

        public void Add(Asteroid asteroid)
        {
            _asteroids.Add(asteroid.GetId(), asteroid);
        }

        public void Remove(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid.GetId());
        }

        public Asteroid Get(int id)
        {
            return _asteroids[id];
        }

        private void Clear()
        {
            _asteroids = new Dictionary<int, Asteroid>();
        }
    }
}