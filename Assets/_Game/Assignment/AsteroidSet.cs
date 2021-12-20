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
            Debug.Log("added asteroid " + asteroid.GetId());
            _asteroids.Add(asteroid.GetId(), asteroid);
        }

        public void Remove(Asteroid asteroid)
        {
            Debug.Log("removed asteroid " + asteroid.GetId());
            _asteroids.Remove(asteroid.GetId());
        }

        public Asteroid Get(int id)
        {
            Debug.Log("trying to get asteroid with id " + id);
            return _asteroids[id];
        }

        private void Clear()
        {
            _asteroids = new Dictionary<int, Asteroid>();
        }
    }
}