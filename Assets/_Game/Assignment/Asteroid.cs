using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt _onAsteroidHit;
        [SerializeField] private ScriptableEventVector3 _onAsteroidSplit;

        [Header("Config:")] [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;
        [SerializeField] private float _minSplitSize;
        


        [Header("References:")] [SerializeField]
        private Transform _shape;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceId;

        public int GetId()
        {
            return _instanceId;
        }

        private bool IsAsteroidLargeEnoughForSplit()
        {
            if (_shape.localScale.x < _minSplitSize)
            {
                return false;
            }

            return true;
        }

        public float GetSize()
        {
            return _shape.localScale.x;
        }
        
        public void SetSize(float size)
        {
            _shape.localScale = new Vector3(size, size, 0f);
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _instanceId = GetInstanceID();

            SetDirection();
            AddForce();
            AddTorque();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
                Destroy(other.gameObject);
                FlagForHit();
            }
        }

        private void FlagForHit()
        {
            _onAsteroidHit.Raise(_instanceId);
            if (IsAsteroidLargeEnoughForSplit())
            {
                _onAsteroidSplit.Raise(transform.position);
            }
        }

        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce(_direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;

            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }
    }
}