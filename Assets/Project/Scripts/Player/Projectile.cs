using SpaceShip.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceShip.Scripts.Player
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _destroyTime = 3f;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Rigidbody2D _rigidbody;

        public GameObject GameObject => gameObject;

        public event Action<IPoolable> Destroyed;

        private void OnEnable()
        {
            _rigidbody.linearVelocity = Vector2.up * _speed;

            StartCoroutine(DestroyProjectile());
        }

        public void Reset()
        {
            Destroyed?.Invoke(this);
        }

        private IEnumerator DestroyProjectile()
        {
            yield return new WaitForSeconds(_destroyTime);

            Reset();
        }
    }
}